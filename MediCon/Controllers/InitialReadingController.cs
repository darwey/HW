using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediCon.Models;
using System.IO;
using MediCon.Classes;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MediCon.Controllers
{
    [SessionTimeout]
    public class InitialReadingController : Controller
    {
        MediconEntities dbMed = new MediconEntities();
        HRISDBEntities hrisDB = new HRISDBEntities();
        // GET: InitialReading

        [UserAccess]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getIRLists(string consultDate)
        {
            var ir = dbMed.sp_ConsultLabExam(consultDate).ToList();
            return Json(ir, JsonRequestBehavior.AllowGet);

         //   var medList = dbMed.fn_MedicineList().OrderBy(a => a.productDesc).ToList();

        }

        [HttpPost]
        public ActionResult getLabHistory(string qrCode, DateTime consultDate)
        {
            try
            {
                string conDate = consultDate.ToShortDateString();
                var conStartDate = DateTime.Parse(conDate + " 00:00:00");
                var conEndDate = DateTime.Parse(conDate + " 23:59:59");

                var labHist = dbMed.LaboratoryExams.Join(dbMed.LaboratoryTests, le => le.labTestID, lt => lt.labTestID, (le, lt) => new { le, lt })
                                                   .Join(dbMed.Referrals, res1 => res1.le.referralID, r => r.referralID, (res1, r) => new { res1, r })
                                                   .Join(dbMed.Consultations, res2 => res2.r.consultID, c => c.consultID, (res2, c) => new { res2, c })
                                                   .Join(dbMed.VitalSigns, res3 => res3.c.vSignID, vs => vs.vSignID, (res3, vs) => new { res3, vs })
                                                   .Where(a => a.vs.qrCode == qrCode && a.res3.c.dateTimeLog >= conStartDate && a.res3.c.dateTimeLog <= conEndDate)
                                                   .Select(b => new
                                                   {
                                                       b.res3.res2.res1.le.labID,
                                                       b.res3.res2.res1.le.labTestID,
                                                       b.res3.res2.res1.lt.labTestName,
                                                       b.res3.res2.res1.le.isTested,
                                                       b.res3.res2.res1.le.isEncoded,
                                                       //b.res3.res2.res1.le.otherLabDesc,
                                                       b.res3.res2.res1.le.xrayDesc,
                                                       b.res3.res2.res1.le.ecgDesc,
                                                       b.res3.res2.res1.le.ultrasoundDesc,
                                                       labPersonID = b.res3.res2.res1.le.personnelID,
                                                       dateTested = b.res3.res2.res1.le.dateTimeLog,
                                                       b.res3.res2.r.referralID,
                                                       b.res3.res2.r.MRDiagnosisID,
                                                       ConsultServiceName = dbMed.Services.FirstOrDefault(aa => aa.serviceID == b.res3.c.serviceID).serviceName,
                                                       refServiceName = dbMed.Services.FirstOrDefault(aa => aa.serviceID == b.res3.res2.r.referredServiceID).serviceName,
                                                       b.res3.c.consultID,
                                                       b.vs.qrCode,
                                                       consultPersonID = b.res3.c.personnelID,
                                                       consultDT = b.res3.c.dateTimeLog,
                                                       consultPersonnel = dbMed.Personnels.Where(c => c.personnelID == b.res3.c.personnelID).Select(e => new { e.personnel_lastName, e.personnel_firstName, e.personnel_midInit, e.personnel_extName }),
                                                   }).ToList();

                return Json(labHist, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", msg = "An error occured while fetching laboratory history.", error = ex }, JsonRequestBehavior.AllowGet);
            }
        }


       //  [UserAccess]
        public ActionResult getScannedLabResult( string qrCode, string fileName)
        {
             
            try
            {
                //string fileDir = @"D:\DavNor Health & Wellness\LaboratoryResults\" + qrCode + "\\" + fileName;
                string fileDir = @"C:\Users\ACER\Documents\LaboratoryResults\" + qrCode + "\\" + fileName;
                var path = Path.Combine(fileDir);
                string ext = Path.GetExtension(fileDir);

                return base.File(path, ext == ".pdf" ? "application/pdf" : "image/png");
            }
            catch
            {
                return Content("File not found!");
            }
        }


       [HttpPost]
        public async Task<ActionResult> saveReading(InitialReading ir, string qrCode)
        {
            try
            {

                var cnt = dbMed.InitialReadings.Count(c => c.consultID == ir.consultID);

                if (cnt > 0)
                {
                    var irRec = dbMed.InitialReadings.SingleOrDefault(a => a.initReadID == ir.initReadID);
                    irRec.initReading = ir.initReading;
                    irRec.remarks = ir.remarks;
                    dbMed.Entry(irRec).State = EntityState.Modified;
                }

                else
                {
                    var irID = new IDgenerator(ir.consultID);

                    ir.initReadID = irID.generateID.Substring(0, 10);
                    ir.dateTimeLog = DateTime.Now;
                    ir.userEncoder = Session["personnelID"].ToString();

                    dbMed.InitialReadings.Add(ir);     
                }


                    string type = "";
                    type = ir.initReading == 2 ? "ABNORMAL" : "NORMAL";
                
                    var emp = hrisDB.vEmployeeHealthWells.SingleOrDefault(a => a.qrCode == qrCode);
                    Recipient r = new Recipient();
                    r.appointee = "DAVNOR CLINIC";
                    r.contactNo = emp.contactNo;
                    r.employee = emp.fullNameFirst;

                    // Send SMS for the updated laboratory schedule
                    var sendSMS = new SendSMSController();
                    if (!String.IsNullOrEmpty(emp.contactNo))
                        await sendSMS.Send(r, false, type);
                
                       
                var affectedRow = dbMed.SaveChanges();

                if (affectedRow == 0)
                    return Json(new { status = "error", msg = "Saving failed!" }, JsonRequestBehavior.AllowGet);

                return Json(new { status = "success", msg = "Status successfully saved!" }, JsonRequestBehavior.AllowGet);
            }
            catch (DbEntityValidationException e)
            {
                return Json(new { responseCode = 500, msg = "Something went wrong. Failed to retrieve data.", exceptionMessage = e.InnerException.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
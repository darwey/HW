using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediCon.Models;

namespace MediCon.Controllers
{
    [SessionTimeout]
    public class PrintController : Controller
    {

        MediconEntities db = new MediconEntities();

        [UserAccess]
        // GET: Print
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult printAccomp(string labRequestID)
        {
            Session["labRequestID"] = labRequestID;
            return Content("YES");
        }

        public ActionResult printRX(string rxID, PatientInfo info, PhysicianInfo physician, int length)
        {
            Session["rxID"] = rxID;
            Session["rxLength"] = length;
            Session["PatientFirstName"] = info.firstName;
            Session["PatientMidName"] = info.middleName == null ? "" : info.middleName;
            Session["PatientLastName"] = info.lastName;
            Session["PatientExtName"] = info.extName == null ? "" : info.extName;
            Session["PatientAddress"] = (info.address == null ? "" : info.address) + " " + (info.brgyDesc == null ? "" : info.brgyDesc) + " " + (info.citymunDesc == null ? "" : info.citymunDesc);
            Session["PatientAge"] = info.age;
            Session["PatientOffice"] = info.office;

            Session["personnel_firstName"] = physician.personnel_firstName;
            Session["personnel_midInit"] = physician.personnel_midInit == null ? "" : physician.personnel_midInit;
            Session["personnel_lastName"] = physician.personnel_lastName;
            Session["personnel_extName"] = physician.personnel_extName == null ? "" : physician.personnel_extName;
            Session["personnel_title"] = physician.title == null ? "" : physician.title;
            Session["personnel_licenseNo"] = physician.licenseNo == null ? "" : physician.licenseNo;

            return Content("YES");
        }

        public class PatientInfo
        {

            public string consultID { get; set; }
            public string fullNameLast { get; set; }
            public string lastName { get; set; }
            public string firstName { get; set; }
            public string middleName { get; set; }
            public string extName { get; set; }
            public string address { get; set; }
            public string brgyDesc { get; set; }
            public string citymunDesc { get; set; }
            public int age { get; set; }
            public string sex { get; set; }
            public string office { get; set; }
            public string positionTitle { get; set; }
            

        }

        public class PhysicianInfo
        {
            public string personnel_lastName { get; set; }
            public string personnel_firstName { get; set; }
            public string personnel_midInit { get; set; }
            public string personnel_extName { get; set; }
            public string title { get; set; }
            public string licenseNo { get; set; }
        }

	public ActionResult printTransmittal(string dateCollected)
        {
            Session["dateCollected"] = dateCollected;
            return Content("YES");
        }

    public ActionResult printLabReq(PatientInfo patient, PhysicianInfo physician)
    {
        var refID = db.Referrals.FirstOrDefault(r => r.consultID == patient.consultID).calendarID;
        var hospID = db.HospitalCalendars.FirstOrDefault(h => h.calendarID == refID).hospitalID;
        var sd = db.HospitalCalendars.FirstOrDefault(h => h.calendarID == refID).scheduleDate;
        string scheduleDate = sd.Value.ToString("MMMM dd, yyyy");

      
        var hospName = db.Hospitals.FirstOrDefault(n => n.hospitalID == hospID).hospitalName;

        Session["consultID"] = patient.consultID;
        Session["fullNameLast"] = patient.fullNameLast;
        Session["sex"] = patient.sex == null ? "" : patient.sex;
        Session["age"] = patient.age;
        Session["hospName"] = hospName == null ? "" : hospName;
        Session["scheduleDate"] = scheduleDate == null ? "" : scheduleDate;
        Session["office"] = patient.office == null ? "" : patient.office;
        Session["positionTitle"] = patient.positionTitle == null ? "" : patient.positionTitle;

        Session["personnel_firstName"] = physician.personnel_firstName;
        Session["personnel_midInit"] = physician.personnel_midInit == null ? "" : physician.personnel_midInit;
        Session["personnel_lastName"] = physician.personnel_lastName;
        Session["personnel_extName"] = physician.personnel_extName == null ? "" : physician.personnel_extName;
        Session["personnel_title"] = physician.title == null ? "" : physician.title;
        Session["personnel_licenseNo"] = physician.licenseNo == null ? "" : physician.licenseNo;

        return Content("YES");
    }

    public ActionResult printReading(string consultDate)
    {
        var cDate = "";
        DateTime date;
        if (DateTime.TryParse(consultDate, out date))
        {
           cDate = date.ToString("MMMM dd, yyyy");
        }

        Session["consultDate"] = consultDate;
        Session["cDate"] = cDate;
        return Content("YES");
    }

    }
}
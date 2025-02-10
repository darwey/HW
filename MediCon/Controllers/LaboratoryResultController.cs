using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using MediCon.ModelTemp;
using MediCon.Classes;
using MediCon.Models;
using System.IO;
using Microsoft.Owin;
using System.Drawing;
using iTextSharp.text.pdf;

namespace MediCon.Controllers
{
    [SessionTimeout]
    public class LaboratoryResultController : Controller
    {
        MediconEntities dbMed = new MediconEntities();
        //private string fileuploadDir = @"D:\DavNor Health & Wellness\LaboratoryResults\";
        private string fileuploadDir = @"C:\Users\ACER\Documents\LaboratoryResults\";

        [UserAccess]
        // GET: LaboratoryResult
        public ActionResult Encoding()
        {
            return View();
        }

        public ActionResult getSpecialist()
        {
            var userList = dbMed.Personnels.Where(x => x.userTypeID == "3").Select(a => new
            {
                a.personnel_firstName,
                a.personnel_midInit,
                a.personnel_lastName,
                a.personnel_extName,
                fullname = a.personnel_firstName + " " + (string.IsNullOrEmpty(a.personnel_midInit) ? "" : (a.personnel_midInit + ". ")) + a.personnel_lastName + " " + (string.IsNullOrEmpty(a.personnel_extName) ? "" : (a.personnel_extName + ". "))+(string.IsNullOrEmpty(a.title) ? "" : (a.title)), 
                a.isActive,
                a.password,
                a.personnelID,
                a.position,
                a.userTypeID,
                a.username,
                a.sex,
                a.contactNum,
                a.licenseNo,
                a.title,
                userDesc = dbMed.UserTypes.FirstOrDefault(b => b.userTypeID == a.userTypeID).userTypeDesc
            }).ToList();
            return Json(userList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getPatientList(DateTime date)
        {
            try
            {
                var lab = dbMed.fn_getLabResult(date).OrderByDescending(x => x.encodeDT).ToList();

                return Json(lab, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", msg = "An error occured while saving your data.", error = ex }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult saveScannedLab(string qrCode, string labID, string file)
        {
            try
            {
                if (file != null)
                {
                    string fileDir = fileuploadDir + qrCode + "\\";

                    //if (!Directory.Exists(fileDir))
                    //    Directory.CreateDirectory(fileDir);

                    //// Check and count if file exist
                    //DirectoryInfo di = new DirectoryInfo(fileDir);
                    //var fileCount = di.EnumerateFiles(labID + "*").Count();

                    //if(fileCount > 0)
                    //{
                    //    var randomID = new IDgenerator(labID);
                    //    labID = labID + "_" + randomID.generateID.Substring(0, 4);
                    //}

                    var result = FileExistChecker(fileDir, labID);

                    var fileData = file.Substring(22);
                    byte[] bytes = Convert.FromBase64String(fileData);

                    Image imageData;
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        imageData = Image.FromStream(ms);
                    }

                    var fullPath = Path.Combine(fileDir, result.Item1 + ".png");
                    imageData.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);

                    if (result.Item2 == 0)
                    {
                        // Save tagging ni LaboratoryExam table
                        //var tag = dbMed.LaboratoryExams.Find(labID);
                        //tag.isEncoded = true;
                        //tag.dateEncoded = DateTime.Now;
                        //tag.encodedBy = Session["personnelID"].ToString();
                        //dbMed.Entry(tag).State = EntityState.Modified;
                        //var affectedRow = dbMed.SaveChanges();
                        var tagResult = TagLabResult(labID);

                        if (tagResult == "error")
                            return Json(new { status = "error", msg = "Failed to save the scanned document." }, JsonRequestBehavior.AllowGet);

                        //return Json(new { status = "success", msg = "Document is successfully saved" }, JsonRequestBehavior.AllowGet);
                    }
                }

                return Json(new { status = "success", msg = "Document is successfully saved" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", msg = "Something went wrong. Failed to retrieve data.", exceptionMessage = ex.InnerException.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult getScannedList(string qrCode, string labID)
        {
            var dir = fileuploadDir + qrCode + "\\";
            List<fileInfo> fileNameList = new List<fileInfo>();

            DirectoryInfo di = new DirectoryInfo(dir);

            foreach (var fi in di.EnumerateFiles(labID + "*"))
            {
                fileNameList.Add(new fileInfo() { Name = fi.Name, Type =  fi.Extension});
            }

            return Json(fileNameList);
        }

        public class fileInfo
        {
            public string Name {get;set;}
            public string Type { get; set; }
        }

        public ActionResult getScannedLabResult(string qrCode, string fileName)
        {
            try
            {
                string fileDir = fileuploadDir + qrCode + "\\" + fileName;
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
        public ActionResult DeleteImg(string qrCode, string fileName)
        {
            try
            {
                string fileDir = fileuploadDir + qrCode + "\\" + fileName;
                var path = Path.Combine(fileDir);
                System.IO.File.Delete(path);

                // Check and count if there are still lab files
                DirectoryInfo di = new DirectoryInfo(fileuploadDir + qrCode);
                var labID = fileName.Remove(fileName.Contains('_') ? fileName.IndexOf('_') : fileName.IndexOf('.'));

                if(di.EnumerateFiles(labID + "*").Count() == 0)
                {
                    // Untag LaboratoryExam table when there is no scanned results in folder
                        var tag = dbMed.LaboratoryExams.Find(labID);
                        tag.isEncoded = null;
                        tag.dateEncoded = null;
                        tag.encodedBy = null;
                        dbMed.Entry(tag).State = EntityState.Modified;
                        var affectedRow = dbMed.SaveChanges();
                }

                return Json(new { status = "success", msg = "Laboratory result is successfully deleted." }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Content("File not found!");
            }   
        }

        private Tuple<string, int> FileExistChecker(string fileDir, string labID)
        {
            if (!Directory.Exists(fileDir))
                Directory.CreateDirectory(fileDir);

            // Check and count if file exist
            DirectoryInfo di = new DirectoryInfo(fileDir);
            var fileCount = di.EnumerateFiles(labID + "*").Count();

            if (fileCount > 0)
            {
                var randomID = new IDgenerator(labID);
                labID = labID + "_" + randomID.generateID.Substring(0, 4);
            }

            var tuple = new Tuple<string, int>(labID, fileCount);
            return tuple;
        }

        private string TagLabResult(string labID)
        {
            // Save tagging ni LaboratoryExam table
            var tag = dbMed.LaboratoryExams.Find(labID);
            tag.isEncoded = true;
            tag.dateEncoded = DateTime.Now;
            tag.encodedBy = Session["personnelID"].ToString();
            dbMed.Entry(tag).State = EntityState.Modified;
            var affectedRow = dbMed.SaveChanges();

            if (affectedRow == 0)
                return "error";

            return "success";
        }

        [HttpPost]
        public ActionResult UploadPdfResult(HttpPostedFileBase file, string qrCode, string labID)
        {
            if (file != null && file.ContentLength > 0)
            {
                string fileDir = fileuploadDir + qrCode + "\\";
                var result = FileExistChecker(fileDir, labID);

                string originalFilePath = Path.Combine(fileDir, result.Item1 + ".pdf");
                file.SaveAs(originalFilePath);

                // Compress the PDF file using iText 7
                string compressedFilePath = Path.Combine(fileDir, result.Item1 + "_compressed.pdf");
             //   CompressPdf(originalFilePath, compressedFilePath);

                if (result.Item2 == 0)
                {
                    var tagResult = TagLabResult(labID);

                    if (tagResult == "error")
                        return Json(new { status = "error", msg = "Failed to upload the document." }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { status = "success", msg = "File is uploaded and compressed successfully" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = "error", msg = "No file is selected" }, JsonRequestBehavior.AllowGet);
        }

        //private void CompressPdf(string inputFilePath, string outputFilePath)
        //{
        //    // Open the existing PDF
        //    using (PdfReader reader = new PdfReader(inputFilePath))
        //    {
        //        // Create a PdfWriter for the output file
        //        using (PdfWriter writer = new PdfWriter(outputFilePath))
        //        {
        //            // Create a PdfDocument object for reading and writing
        //            using (PdfDocument pdfDoc = new PdfDocument(reader, writer))
        //            {
        //                // Perform compression (e.g., through optimization)
        //                pdfDoc.Close();
        //            }
        //        }
        //    }
        //}

        //[HttpPost]
        //public ActionResult UploadPdfResult(string file, string qrCode, string labID)
        //{
        //    // Verify that the user selected a file
        //    if (file != null)
        //    {
        //        string fileDir = fileuploadDir + qrCode + "\\";

        //        var result = FileExistChecker(fileDir, labID);

        //        var sub = file.Substring(file.IndexOf("base64") + 7);
        //        byte[] bytes = Convert.FromBase64String(sub);

        //        System.IO.FileStream stream = new FileStream(fileDir + result.Item1 + ".pdf", FileMode.CreateNew);
        //        System.IO.BinaryWriter writer = new BinaryWriter(stream);
        //        writer.Write(bytes, 0, bytes.Length);
        //        writer.Close();

        //        if (result.Item2 == 0)
        //        {
        //            var tagResult = TagLabResult(labID);

        //            if (tagResult == "error")
        //                return Json(new { status = "error", msg = "Failed to upload the document." }, JsonRequestBehavior.AllowGet);
        //        }

        //        return Json(new { status = "success", msg = "File is uploaded successfully" }, JsonRequestBehavior.AllowGet);

        //    }

        //    return Json(new { status = "error", msg = "No file is selected" }, JsonRequestBehavior.AllowGet);
        //}
    }
}
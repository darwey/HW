using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediCon.Models;

namespace MediCon.Controllers
{
    public class PackageLabTestController : Controller
    {
        MediconEntities dbMed = new MediconEntities();
        
        // GET: PackageLabTest
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult getHospitalList()
        {
            try
            {
                var medList = dbMed.Hospitals.Where(a => a.hospitalID != "HPL003" && a.hospitalID != "HPL004").ToList();

                return Json(medList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", msg = "An error occured while fetching the medicines.", error = ex }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
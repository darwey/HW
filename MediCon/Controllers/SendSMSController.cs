﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using MediCon.Models;
using MediCon.Classes;

namespace MediCon.Controllers
{
    public class SendSMSController : Controller
    {
        MediconEntities dbMed = new MediconEntities();
        HRISDBEntities hrisDB = new HRISDBEntities();

        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        private static readonly HttpClient client = new HttpClient();

        // GET: SendSMS
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task Send(Recipient info, bool isHospital, string type)
        {
            var values = new Dictionary<string, string>();
            values.Add("app_key", "DavN0rHR!S");
            values.Add("app_secret", "gyNJUQ486EBZ9tZeNpdqPjMuCn17tgcr");
            values.Add("msisdn", info.contactNo);
            values.Add("shortcode_mask", "PG DavNor");
            values.Add("rcvd_transid", "S858340416-9601");
            values.Add("is_intl", "false");

            if (type == "labSched")
            {
                if (isHospital)
                    values.Add("content", "Hi " + info.employee + "! Your laboratory schedule at PEEDO-" + info.appointee + " is on " + info.schedule.ToLongDateString() + ", at 7AM"
                                           + " Kindly strictly follow your schedule and observe the fasting reminders provided to you. For any concerns, please reach the PHRMO-Admin Division");

                else
                {
                    var physician = dbMed.Personnels.SingleOrDefault(a => a.personnelID == info.appointee);
                    var physicianName = "Dr. " + physician.personnel_firstName + " " + physician.personnel_lastName;

                    values.Add("content", "Hi " + info.employee + "! We would like to inform you that your laboratory results are already available and you are scheduled to visit " + physicianName +
                        " on " + info.schedule.ToLongDateString() + ", at DavNor Employees' Clinic. It is highly encouraged for you to strictly follow the assigned schedule due to the limited slots in the physicians' schedule. For any schedule changes and other concerns, kindly inform the PHRMO-Admin Division.");
                }
            }
            else if (type == "changeSched")
            {
                values.Add("content", "Hi " + info.employee + "! Your laboratory NEW schedule at PEEDO-" + info.appointee + " is on " + info.schedule.ToLongDateString() + ", at 7AM"
                                       + " Kindly strictly follow your schedule and observe the fasting reminders provided to you. For any concerns, please reach the PHRMO-Admin Division");
            
            }

            else if (type == "NORMAL")
            {
                values.Add("content", "Good day " + info.employee + "! Per initial assessment by our physician, your lab results are within normal. No need for a follow-up. Kindly continue your healthy diet and lifestyle."
                                       + " If you wish to have your results explained further, please contact the PHRMO-Admin for a schedule. Thank you.");
            }

            else if (type == "ABNORMAL")
            {
                values.Add("content", "Good day " + info.employee + "! Per initial assessment by our physician, your lab results require further reading. Kindly contact the PHRMO-Admin for a schedule follow-up consultation as soon as possible." +
                    " Thank you.");

            }


            else
            {
                values.Add("content", "Hi " + info.employee + "! We regret to inform you that your health & wellness medical consultation at our clinic on " + info.schedule.ToLongDateString() + ", was cancelled because the physician will not be available on the said date." +
                    "Please create a new booking/appointment at your convenience in your HRIS. Thank you.");
            }
            

            var content = new FormUrlEncodedContent(values);

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var response = await client.PostAsync("https://api.m360.com.ph/v3/api/broadcast", content);
            var responseString = await response.Content.ReadAsStringAsync();
        }

        [HttpPost]
        public async Task GroupMessageSend(string calendarID, DateTime consultDate, DateTime followUpDate, string personnelID)
        {
            string conDate = consultDate.ToShortDateString();
            var conStartDate = DateTime.Parse(conDate + " 00:00:00");
            var conEndDate = DateTime.Parse(conDate + " 23:59:59");

            var consultList = dbMed.Consultations.Join(dbMed.VitalSigns, con => con.vSignID, vs => vs.vSignID, (con, vs) => new { con, vs })
                                                 .Join(dbMed.Personnels, r1 => r1.con.personnelID, per => per.personnelID, (r1, per) => new { r1, per })
                                                     .Where(a => a.r1.con.dateTimeLog >= conStartDate && a.r1.con.dateTimeLog <= conEndDate && a.r1.con.personnelID == personnelID)
                                                     .Select(b => new
                                                     {
                                                         b.r1.vs.qrCode,
                                                         b.per.personnel_firstName,
                                                         b.per.personnel_midInit,
                                                         b.per.personnel_lastName,
                                                         b.per.personnel_extName
                                                     }).Distinct().ToList();

            var hrRec = consultList.Join(hrisDB.vEmployeeHealthWells, hw => hw.qrCode, emp => emp.qrCode, (hw, emp) => new { hw, emp })
                                    .Select(a => new
                                    {
                                        a.hw.qrCode,
                                        a.emp.idNo,
                                        a.emp.fullNameLast,
                                        a.emp.contactNo,
                                        physician = a.hw.personnel_firstName + " " + (a.hw.personnel_midInit == null ? "" : a.hw.personnel_midInit + " ")
                                                    + a.hw.personnel_lastName + (a.hw.personnel_extName == null? "" : " " + a.hw.personnel_extName)
                                    }).OrderBy(b => b.fullNameLast);

            foreach (var item in hrRec)
            {
                await Task.Delay(5000);

                if (item.contactNo != null)
                {
                    var values = new Dictionary<string, string>();
                    values.Add("app_key", "DavN0rHR!S");
                    values.Add("app_secret", "gyNJUQ486EBZ9tZeNpdqPjMuCn17tgcr");
                    values.Add("msisdn", item.contactNo);
                    values.Add("shortcode_mask", "PG DavNor");
                    values.Add("rcvd_transid", "S858340416-9601");
                    values.Add("is_intl", "false");

                    //values.Add("content", "Hi " + item.fullNameLast + "! We would like to inform you that your laboratory results are already available and you are scheduled to visit Dr. " + item.physician +
                    //    " on " + followUpDate.ToLongDateString() + ", at DavNor Employees' Clinic. It is highly encouraged for you to strictly follow the assigned schedule due to the limited slots in the physicians' schedule. For any schedule changes and other concerns, kindly inform the PHRMO-Admin Division.");

                    values.Add("content", "Hi " + item.fullNameLast + "! We would like to inform you that your laboratory results are already available and you are scheduled to visit Dr. " + item.physician +
                    " on " + followUpDate.ToLongDateString() + ", at DavNor Gymnasium as part of the Employees Health, Legal Consultation and Consumer Rights Awareness. It is highly encouraged for you to strictly follow the" +
                    "set time per department as identified in the disseminated memo. For any concern/clarification kindly contact the PHRMO-Admin Division.");

                    var content = new FormUrlEncodedContent(values);

                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    var response = await client.PostAsync("https://api.m360.com.ph/v3/api/broadcast", content);
                    var responseString = await response.Content.ReadAsStringAsync();
                }
            }
        }
      
    }
}
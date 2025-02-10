using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Reporting;

namespace MediCon.Report
{
    public partial class MediConRpt : System.Web.UI.Page
    {

        InstanceReportSource rpt = new InstanceReportSource();
        protected void Page_Load(object sender, EventArgs e)
        {
            var labRequestID = "";

            switch (Request["type"])

            {
                case "lrrf":
                    labRequestID = Session["labRequestID"].ToString();
                    rpt.ReportDocument = new LRRF.LRRFRpt();
                    rpt.Parameters.Add("labRequestID", labRequestID);
                    break;

                case "prescription":
                    rpt.Parameters.Add("rxID", Session["rxID"].ToString());
                    rpt.Parameters.Add("rxLength", Session["rxLength"].ToString());
                    rpt.Parameters.Add("PatientFirstName", Session["PatientFirstName"].ToString());
                    rpt.Parameters.Add("PatientMidName", Session["PatientMidName"].ToString());
                    rpt.Parameters.Add("PatientLastName", Session["PatientLastName"].ToString());
                    rpt.Parameters.Add("PatientExtName", Session["PatientExtName"].ToString());
                    rpt.Parameters.Add("PatientAddress", Session["PatientAddress"].ToString());
                    rpt.Parameters.Add("PatientAge", Session["PatientAge"].ToString());
                    rpt.Parameters.Add("PatientOffice", Session["PatientOffice"].ToString());

                    rpt.Parameters.Add("personnel_firstName", Session["personnel_firstName"].ToString());
                    rpt.Parameters.Add("personnel_midInit", Session["personnel_midInit"].ToString());
                    rpt.Parameters.Add("personnel_lastName", Session["personnel_lastName"].ToString());
                    rpt.Parameters.Add("personnel_extName", Session["personnel_extName"].ToString());
                    rpt.Parameters.Add("personnel_title", Session["personnel_title"].ToString());
                    rpt.Parameters.Add("personnel_licenseNo", Session["personnel_licenseNo"].ToString());
                    rpt.ReportDocument = new Prescription.RX();
                    break;


                case "prescriptionList":

                    rpt.Parameters.Add("rxID", Session["rxID"].ToString());
                    rpt.Parameters.Add("fullName", Session["fullName"].ToString());
                    rpt.Parameters.Add("PatientAddress", Session["PatientAddress"].ToString());
                    rpt.Parameters.Add("PatientAge", Session["PatientAge"].ToString());

                    rpt.Parameters.Add("personnelFullName", Session["personnelFullName"].ToString());
                    rpt.Parameters.Add("personnel_title", Session["personnel_title"].ToString());
                    rpt.Parameters.Add("personnel_licenseNo", Session["personnel_licenseNo"].ToString());
                    rpt.Parameters.Add("mp_dateTimeRx", Session["mp_dateTimeRx"].ToString());

                    rpt.ReportDocument = new Prescription.rxList();
                    break;

                case "masterList":
                    rpt.Parameters.Add("scheduleDate", Session["scheduleDate"].ToString());
                    rpt.Parameters.Add("labTestID", Session["labTestID"].ToString());
                    rpt.Parameters.Add("hospitalID", Session["hospitalID"].ToString());
                    rpt.Parameters.Add("labTestName", Session["labTestName"].ToString());
                    rpt.ReportDocument = new MasterList.PrintMasterList();
                    break;

                case "transmittal":
                    rpt.Parameters.Add("dateCollected", Session["dateCollected"].ToString());
                    rpt.ReportDocument = new LRRF.SputumTransmittal();
                    break;

                case "labRequest":

                    rpt.Parameters.Add("personnel_firstName", Session["personnel_firstName"].ToString());
                    rpt.Parameters.Add("personnel_midInit", Session["personnel_midInit"].ToString());
                    rpt.Parameters.Add("personnel_lastName", Session["personnel_lastName"].ToString());
                    rpt.Parameters.Add("personnel_extName", Session["personnel_extName"].ToString());
                    rpt.Parameters.Add("personnel_title", Session["personnel_title"].ToString());
                    rpt.Parameters.Add("personnel_licenseNo", Session["personnel_licenseNo"].ToString());
                    rpt.Parameters.Add("scheduleDate", Session["scheduleDate"].ToString());
                    rpt.Parameters.Add("office", Session["office"].ToString());
                    rpt.Parameters.Add("positionTitle", Session["positionTitle"].ToString());
                    
                    rpt.Parameters.Add("consultID", Session["consultID"].ToString());
                    rpt.Parameters.Add("fullNameLast", Session["fullNameLast"].ToString());
                    rpt.Parameters.Add("sex", Session["sex"].ToString());
                    rpt.Parameters.Add("age", Session["age"].ToString());
                    rpt.Parameters.Add("hospName", Session["hospName"].ToString());
                    rpt.ReportDocument = new RequestForm.RequestForm();
                    break;

                case "initialReading":
                    rpt.Parameters.Add("consultDate", Session["consultDate"].ToString());
                    rpt.Parameters.Add("cDate", Session["cDate"].ToString());
                    rpt.ReportDocument = new InitialReading.InitialReadingRpt();
                    break;
            }

            MediconReportViewer.ReportSource = rpt;

        }
    }
}
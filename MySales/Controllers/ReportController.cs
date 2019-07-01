using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySales.Models;
using Microsoft.Reporting.WebForms;
using System.Web.UI.WebControls;
using ReportViewerForMvc;

namespace MySales.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        // GET: Report
        public OnlineShopEntities18 db = new OnlineShopEntities18();
        public ActionResult Index()
        {
           
                ViewBag.CriteriaID = new SelectList(db.Criteria1, "CriteriaID", "CriteriaDescription");


                return View();
          
         
        }
        public ActionResult OrderCount(string bDate, string eDate, Nullable<int> id)
        {
            DateTime d1 = Convert.ToDateTime(bDate);
            DateTime d2 = Convert.ToDateTime(eDate);
            //if (wId == 0)
            //{
            //    getwID = wId.GetValueOrDefault(); ;
            //}
            ReportViewer reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
                SizeToReportContent = true,
                Width = Unit.Percentage(50),
                Height = Unit.Percentage(50)
            };


            var v = (from x in db.Orders where x.CriteriaID == id select x).FirstOrDefault();
            List<Online_report_Result> obj = db.Online_report(id,d1,d2).ToList();
            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Detail.rdlc";

            //ReportParameter rp2 = new ReportParameter("wName", v.OrderId.ToString());

            // reportViewer.LocalReport.SetParameters(new ReportParameter[] { rp2 });

            ReportDataSource rdc = new ReportDataSource("dateWisereport", obj);
            reportViewer.LocalReport.DataSources.Add(rdc);

            reportViewer.LocalReport.Refresh();
            reportViewer.Visible = true;

            ViewBag.ReportViewer = reportViewer;
            return PartialView("OrderCount");

        }
    }
}
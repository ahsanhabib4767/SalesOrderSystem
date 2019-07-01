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
    public class PortController : Controller
    {
        // GET: Report
        public OnlineShopEntities18 db = new OnlineShopEntities18();
        public ActionResult Index()
        {
           
                //ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId");
                var data = db.Orders.Select(s => new
                {
                    Text = s.Wotype+ "----"+ s.workOrderNo + " --- " + s.OrderId + "---" + s.OrderDate,
                    Value = s.OrderId
                })
   .ToList();
                ViewBag.OrderId = new SelectList(data, "Value", "Text");


                return View();
           
         

        }
        public ActionResult Port(Nullable<int> id)
        {

            ReportViewer reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
                SizeToReportContent = true,
                Width = Unit.Percentage(60),
                Height = Unit.Percentage(50)
            };


            var v = (from x in db.Orders where x.OrderId == id select x).FirstOrDefault();
            List<Online_odr_Result> posmRecIss = db.Online_odr(id).ToList();
            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Invoice.rdlc";

            //ReportParameter rp2 = new ReportParameter("wName", v.OrderId.ToString());

            // reportViewer.LocalReport.SetParameters(new ReportParameter[] { rp2 });

            ReportDataSource rdc = new ReportDataSource("dsM", posmRecIss);
            reportViewer.LocalReport.DataSources.Add(rdc);

            reportViewer.LocalReport.Refresh();
            reportViewer.Visible = true;

            ViewBag.ReportViewer = reportViewer;
            return PartialView("Port");

        }
    }
}
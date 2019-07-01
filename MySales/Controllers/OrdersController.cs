using MySales.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySales.Models.ViewModel;
using PagedList;
using PagedList.Mvc;
using Microsoft.Reporting.WebForms;
using System.Web.UI.WebControls;
using ReportViewerForMvc;


namespace MySales.Controllers
{
 [Authorize]
    public class OrdersController : Controller
    {
        // GET: Orders
        OnlineShopEntities18 db = new OnlineShopEntities18();
        public ActionResult Index()
        {


            OnlineShopEntities18 db = new OnlineShopEntities18();
                List<tblCustomer> OrderAndCustomerList = db.tblCustomers.ToList();
                List<Criteria> ct = db.Criteria1.ToList();
                ViewBag.CriteriaId = new SelectList(db.Criteria1, "CriteriaID", "CriteriaDescription");
                ViewBag.CustomerID = new SelectList(db.tblCustomers, "CustomerID", "CustomerName");

                ViewBag.BrandID = new SelectList(db.tblBrands, "BrandID", "BrandDescription");
                ViewBag.Alist = new SelectList(GetActivityList(), "ActivityId", "ActivityName");
            ViewBag.des = new SelectList(db.descriptionTables,"description","description");
                ViewBag.act = db.Activities.ToList();
                // ViewBag.StateID = new SelectList(db.SubActivities, "StateID", "StateName");
                int value = db.Orders.Max(a => a.workOrderNo);
                int num = value;


                Order ord = new Order
                {
                    workOrderNo = (num + 1),

                };




                return View(ord);

            
          
        }
        //For Cascade
        public List<Activity> GetActivityList()
        {
            OnlineShopEntities18 db = new OnlineShopEntities18();
            List<Activity> activities = db.Activities.ToList();
            return activities;
        }
        public ActionResult GetSubActivityList(int ActivityId)
        {
            OnlineShopEntities18 db = new OnlineShopEntities18();
            List<SubActivity> subact = db.SubActivities.Where(x => x.ActivityId == ActivityId).ToList();
            ViewBag.list = new SelectList(subact, "StateID", "StateName");
            return PartialView("GetD");
        }

        //
        //Add Orders
        //by Ahsan
        [HttpPost]
        public ActionResult Add(Order order)
        {
            OnlineShopEntities18 db = new OnlineShopEntities18();
            List<Order> list = db.Orders.ToList();

            Order ord = new Order();
            //var autoid = db.Orders.SingleOrDefault(a => a.workOrderNo == "Order");

            ord.OrderId = order.OrderId;
            ord.ProductName = order.ProductName;
           
            ord.CustomerId = order.CustomerId;
            ord.BrandID = order.BrandID;
            ord.CriteriaID = order.CriteriaID;
            ord.workOrderNo = order.workOrderNo;
            ord.OrderDate = order.OrderDate;
            ord.DeliveryDate = order.DeliveryDate;
            ord.Place = order.Place;
            ord.Heading = order.Heading;
            db.Orders.Add(ord);
            db.SaveChanges();




            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult SaveOrder(VMOrder O)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (OnlineShopEntities18 dc = new OnlineShopEntities18())
                {
                    Order order = new Order
                    {
                        OrderId = O.OrderId,
                        ProductName = O.ProductName,

                        CustomerId = O.CustomerId,
                        BrandID = O.BrandID,
                        CriteriaID = O.CriteriaID,
                        workOrderNo = O.workOrderNo,
                        billsubmission = O.billsubmission,
                        cancel = O.cancel,
                        advance = O.advance,
                        Wotype = O.Wotype,
                       
                       

                };
                    foreach (var i in O.OrderDetails)
                    {
                        //
                        // i.TotalAmount = 
                        order.OrderDetails.Add(i);
                    }
                    dc.Orders.Add(order);
                    dc.SaveChanges();
                    status = true;
                }
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }
        //**Code used for getting workorder number according to activity like CSD,AF****
        public JsonResult GetStockQty(int activityid)
        {



            int Wotype = 0;




            try
            {


                using (OnlineShopEntities18 db = new OnlineShopEntities18())
                {



                    var subact = db.Orders.Where(x => x.CriteriaID == activityid).Max(x => x.Wotype);
                    //var subact = (from x in db.Orders where x.type == activityid select x).FirstOrDefault();

                    Wotype = (int)subact + 1;


                    // }
                    return new JsonResult { Data = new { Wotype = Wotype }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


                }
            }
            catch (Exception)
            {
                return Json(new { status = "error", message = "Product Description Not Found" });

            }
        }

        //Show Order Lists
        //by Ahsan
        /* public ActionResult List()
         {
             OnlineShopEntities16 db = new OnlineShopEntities16();
             var data = db.Orders.Select(s => new
             {
                 Text = s.workOrderNo + " , " + s.ProductName,
                 Value = s.OrderId
             })
     .ToList();
             ViewBag.Orderlists = new SelectList(data, "Value", "Text");

             // ViewBag.workOrderNo = new SelectList(db.Orders, "OrderId", "workOrderNo");



             return View();
         }*/
        public ActionResult Edit(int id)
        {
            using (OnlineShopEntities18 db = new OnlineShopEntities18())
            {
                return View(db.Orders.Where(x => x.OrderId == id).FirstOrDefault());
            }
        }
        // Get Edit
        [HttpPost]
        public ActionResult Edit(int id, Order order)
        {
            try
            {
                using (OnlineShopEntities18 db = new OnlineShopEntities18())
                {
                    db.Entry(order).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("orderlist");
            }
            catch
            {
                return View();
            }

        }
        public ActionResult Details(int id)
        {
            using (OnlineShopEntities18 db = new OnlineShopEntities18())
            {
                return View(db.Orders.Where(x => x.OrderId == id).FirstOrDefault());
            }

        }
       /* public ActionResult Viewof(int id)
        {
            OnlineShopEntities16 db = new OnlineShopEntities16();

            var data = db.Orders.Where(x => x.OrderId == id)
    .Select(s => new
    {
        Text = s.ProductName + " , " + s.OrderDate + " , " + s.workOrderNo + " , " + s.Heading,
        Value = s.OrderId
    })
    .ToList();
            ViewBag.Orderlists = new SelectList(data, "Value", "Text");


            return View();
        }*/
        //Load Orders on Text Fields To Edit
        //by Ahsan

       /* public JsonResult GetStockQty(int pId)
        {
            string productname;
           
            int Ord;
            int cid;
            String work;
            int bid;
            int? crid;
           DateTime? orderdate;
            DateTime? deldate;
            string place;
            String heading;



            try
            {
                // Here "MyDatabaseEntities " is dbContext, which is created at time of model creation.

                // using (OnlineShopEntities11 db = new OnlineShopEntities11())
                // {


                var V = (from x in db.Orders where x.OrderId == pId select x).FirstOrDefault();

                productname = V.ProductName;
               
                Ord = V.OrderId;
                cid = V.CustomerId;
                work = V.workOrderNo;
                bid = V.BrandID;
                crid = V.CriteriaID;
                orderdate = V.OrderDate;
                deldate = V.DeliveryDate;
                place = V.Place;
                heading = V.Heading;
         

                // }
                return new JsonResult { Data = new { Ord = Ord, cid = cid, work = work, bid = bid, crid = crid, productname = productname,orderdate = orderdate,deldate = deldate,place= place,heading=heading}, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


            }
            catch (Exception)
            {
                return Json(new { status = "error", message = "Product Description Not Found" });
                // throw ex;
            }
        }


        [HttpPost]
        public ActionResult GetAllCity(int? value)
        {
            var list = new List<Order>();
            if (value == 1)
            {

                list = db.Orders.Where(x => x.CriteriaID == 1).ToList();
            }
            else if (value == 2)
            {
                list = db.Orders.Where(x => x.CriteriaID == 2).ToList();
            }
            else
            {
                list = db.Orders.ToList();
            }

            return Json(list);
        }
        */
        public ActionResult PrintAllReport()
        {
            var report = new ActionAsPdf("Index");
            return report;
        }
        public ActionResult IndexById(int id)
        {
            var emp = db.Orders.Where(e => e.OrderId == id).First();
            return View(emp);
        }
        public ActionResult PrintSalarySlip(int id)
        {
            var report = new ActionAsPdf("IndexById", new { id = id });
            return report;
        }
        [HttpGet]
        public ActionResult orderlist(string search,int? i)
        {
            OnlineShopEntities18 db = new OnlineShopEntities18();

            IEnumerable<Order> orderlists = db.Orders.ToList();

            return View(db.Orders.OrderByDescending(x=>x.workOrderNo).ToList().ToPagedList(i ?? 1, 15));
        }

        [HttpPost]
        public ActionResult Update(Order order)
        {
            db.Entry(order).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            using (OnlineShopEntities18 db = new OnlineShopEntities18())
            {
                return View(db.Orders.Where(x => x.OrderId == id).FirstOrDefault());
            }
        }
        // Get Edit
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (OnlineShopEntities18 db = new OnlineShopEntities18())
                {
                    Order order = db.Orders.Where(x => x.OrderId == id).FirstOrDefault();
                    db.Orders.Remove(order);

                    db.SaveChanges();
                }
                return RedirectToAction("orderlist");
            }
            catch
            {
                return View();
            }

        }
        ///////////////////////////Report/////////////////////////////

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


        ////////////////////////////////////end/////////////////////////

    }
}



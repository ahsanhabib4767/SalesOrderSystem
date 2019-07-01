using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySales.Models;
using MySales.Models.ViewModel;

namespace MySales.Controllers
{ [Authorize]
    public class TestController : Controller
    {
        // GET: Test
        string username;
        public ActionResult Index()
        {

           
                OnlineShopEntities18 db = new OnlineShopEntities18();
                List<tblCustomer> OrderAndCustomerList = db.tblCustomers.ToList();
                List<Criteria> ct = db.Criteria1.ToList();
                ViewBag.CriteriaId = new SelectList(db.Criteria1, "CriteriaID", "CriteriaDescription");
                ViewBag.CustomerId = new SelectList(db.tblCustomers, "CustomerId", "CustomerName");

                ViewBag.BrandID = new SelectList(db.tblBrands, "BrandID", "BrandDescription");
                int value = db.Orders.Max(a => a.workOrderNo);
                int num = value;


                Order ord = new Order
                {
                    workOrderNo = (num + 1),

                };




                return View(ord);


                //ViewBag.workOrderNo = new SelectList(db.Orders, "OrderId", "workOrderNo");
                //connecting to form for drpdownlist

          
        }
        [HttpPost]
        public JsonResult SaveOrder(VMOrder O)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (OnlineShopEntities18 dc = new OnlineShopEntities18())
                {
                    username = User.Identity.Name;
                    //   Convert.ToInt32(Session["UserID"]);
                    var u = dc.UserProfiles.Where(x => x.UserName == username).FirstOrDefault();

                    Order order = new Order
                    {
                        OrderId = O.OrderId,
                        ProductName = O.ProductName,

                        CustomerId = O.CustomerId,
                        BrandID = O.BrandID,
                        CriteriaID = O.CriteriaID,
                        ActivityId = O.ActivityId,
                        StateID = O.StateID,
                        workOrderNo = O.workOrderNo,
                        OrderDate = O.OrderDate,
                        DeliveryDate = O.DeliveryDate,
                        Place = O.Place,
                        Heading = O.Heading,
                        UserId = u.UserId,
                     
                        billsubmission = O.billsubmission,
                        cancel = O.cancel,
                        advance = O.advance,
                        Wotype = O.Wotype,
                        warrenty = O.warrenty
                    };
                    foreach (var i in O.OrderDetails)
                    {
                        //
                        // i.TotalAmount = 
                        order.OrderDetails.Add(i);
                    }
                    //order.UserId = Convert.ToInt32(Session["UserID"]);
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


    }
}
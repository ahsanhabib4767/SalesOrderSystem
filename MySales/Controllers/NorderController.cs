using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MySales.Models;

namespace MySales.Controllers
{
    [Authorize]
    public class NorderController : Controller
    {
        OnlineShopEntities18 _db = new OnlineShopEntities18();
        // GET: Orders
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
                return View();
           
           
        }
        //Dropdown of selected catagory
        public PartialViewResult GetOrdersByCategory(int? categoryId)
        {
            if (categoryId == 1)
            {
                ViewBag.Orders = new SelectList(_db.Orders.Where(x => x.CriteriaID == categoryId).ToList(), "OrderId", "Wotype", "workOrderNo");
            }
            else if (categoryId == 2)
            {
                ViewBag.Orders = new SelectList(_db.Orders.Where(x => x.CriteriaID == categoryId).ToList(), "OrderId", "Wotype", "workOrderNo");
            }
            else if (categoryId == 3)
            {
                ViewBag.Orders = new SelectList(_db.Orders.Where(x => x.CriteriaID == categoryId).ToList(), "OrderId", "Wotype", "workOrderNo");
            }
           
            return PartialView();
        }
        //Details of master Detail
        [HttpPost]
        public PartialViewResult GetOrdersDetailsById(int orderId)
        {
            List<OrderDetail> orderDetailss = _db.OrderDetails.Where(x => x.OrderID == orderId).ToList();
            return PartialView(orderDetailss);
        }

        public PartialViewResult GetOrderById(int orderId)
        {
            var order = _db.Orders.FirstOrDefault(x => x.OrderId == orderId);
            var orderDetails = _db.OrderDetails.Where(x => x.OrderID == orderId).ToList();
            if (order != null) order.OrderDetailss = orderDetails;
            return PartialView(order);
        }
        //Update order with master Details
        [HttpPost]
        public ActionResult UpdateOrder(Order order)
        {
            if (order != null)
            {
                _db.Entry(order).State = EntityState.Modified;
                var any = _db.SaveChanges();
                if (any > 0)
                {
                    if (order.OrderDetailss != null && order.OrderDetailss.Any())
                    {
                        foreach (var orderDetailse in order.OrderDetailss)
                        {
                            _db.Entry(orderDetailse).State = EntityState.Modified;
                            _db.SaveChanges();
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }
        //update orders
        [HttpPost]
        public ActionResult EditOrderDetails(List<OrderDetail> orderDetailList)
        {
            if (orderDetailList != null && orderDetailList.Any())
            {
                foreach (var orderDetailse in orderDetailList)
                {
                    _db.Entry(orderDetailse).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}

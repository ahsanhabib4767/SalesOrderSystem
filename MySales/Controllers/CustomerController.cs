using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySales.Models;
using System.Data.Entity.Validation;
using System.Net;
using System.Data.Entity;
using System.Data;

namespace MySales.Controllers
{


    // GET: Home
    [Authorize]
    public class CustomerController : Controller
    {
        OnlineShopEntities18 db = new OnlineShopEntities18();
        // GET: Home
        public ActionResult Index()
        {
            OnlineShopEntities18 db = new OnlineShopEntities18();
            //List<Party> list = db.Parties.ToList();
            IEnumerable<tblCustomer> partylist = db.tblCustomers.ToList();
            return View();

        }
        //creating entry controller
        [HttpPost]
        public ActionResult Add(tblCustomer model)
        {
            //ViewBag.Message = "Your party page.";
            OnlineShopEntities18 db = new OnlineShopEntities18();
            //string result = "Completed!";
            List<tblCustomer> list = db.tblCustomers.ToList();

            tblCustomer par = new tblCustomer();
            par.DirectPayment = model.DirectPayment;
            par.CustomerName = model.CustomerName;
            par.Address = model.Address;
            par.Phone = model.Phone;
            db.tblCustomers.Add(par);
            db.SaveChanges();

            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult List()
        {
            OnlineShopEntities18 db = new OnlineShopEntities18();

            IEnumerable<tblCustomer> partylist = db.tblCustomers.ToList();

            return View(partylist);
        }

        // creating details view controller(GET)

        public ActionResult Details(int id)
        {
            using (OnlineShopEntities18 db = new OnlineShopEntities18())
            {
                return View(db.tblCustomers.Where(x => x.CustomerID == id).FirstOrDefault());
            }

        }
        // creating edit for update
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            using (OnlineShopEntities18 db = new OnlineShopEntities18())
            {
                return View(db.tblCustomers.Where(x => x.CustomerID == id).FirstOrDefault());
            }
        }
        // Get Edit
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id, tblCustomer party)
        {
            try
            {
                using (OnlineShopEntities18 db = new OnlineShopEntities18())
                {
                    db.Entry(party).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }

        }
        /////Delete
        public ActionResult Delete(int id)
        {
            using (OnlineShopEntities18 db = new OnlineShopEntities18())
            {
                return View(db.tblCustomers.Where(x => x.CustomerID == id).FirstOrDefault());
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
                    tblCustomer par = db.tblCustomers.Where(x => x.CustomerID == id).FirstOrDefault();
                    db.tblCustomers.Remove(par);

                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }

        }

    }//end of controller
}

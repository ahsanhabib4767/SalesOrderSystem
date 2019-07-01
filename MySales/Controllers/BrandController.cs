using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySales.Models;
using System.Data.Entity.Validation;
using System.Net;
using System.Data.Entity;

namespace MySales.Controllers
{


    // GET: Home
    [Authorize]
    public class BrandController : Controller
    {
        OnlineShopEntities18 db = new OnlineShopEntities18();
        // GET: Home
        public ActionResult Index()
        {

            OnlineShopEntities18 db = new OnlineShopEntities18();
            //List<Party> list = db.Parties.ToList();
            IEnumerable<tblBrand> partylist = db.tblBrands.ToList();
            return View();


        }
        //creating entry controller
        [HttpPost]
        public ActionResult Add(tblBrand model)
        {
            //ViewBag.Message = "Your party page.";
            OnlineShopEntities18 db = new OnlineShopEntities18();
            List<tblBrand> list = db.tblBrands.ToList();

            tblBrand tblBrand = new tblBrand();

            tblBrand.BrandDescription = model.BrandDescription;
           
            db.tblBrands.Add(tblBrand);
            db.SaveChanges();
           
            return RedirectToAction("List");

        }
        [HttpGet]
        public ActionResult List()
        {
            OnlineShopEntities18 db = new OnlineShopEntities18();

            IEnumerable<tblBrand> partylist = db.tblBrands.ToList();

            return View(partylist);
        }

        // creating details view controller(GET)

        public ActionResult Details(int id)
        {
            using (OnlineShopEntities18 db = new OnlineShopEntities18())
            {
                return View(db.tblBrands.Where(x => x.BrandID == id).FirstOrDefault());
            }

        }
        // creating edit for update
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            using (OnlineShopEntities18 db = new OnlineShopEntities18())
            {
                return View(db.tblBrands.Where(x => x.BrandID == id).FirstOrDefault());
            }
        }
        // Get Edit
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id, tblBrand party)
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
                return View(db.tblBrands.Where(x => x.BrandID == id).FirstOrDefault());
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
                    tblBrand tb = db.tblBrands.Where(x => x.BrandID == id).FirstOrDefault();
                    db.tblBrands.Remove(tb);

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

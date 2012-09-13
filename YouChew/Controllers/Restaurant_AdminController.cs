using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouChew.Models;
using YouChew.Models.ORM;

namespace YouChew.Controllers
{
    public class Restaurant_AdminController : Controller
    {
        private SiteContext db = new SiteContext();

        //
        // GET: /Restaurant_Admin/

        public ActionResult Index()
        {
            return View(db.Restaurants.ToList());
        }

        //
        // GET: /Restaurant_Admin/Details/5

        public ActionResult Details(Guid id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //
        // GET: /Restaurant_Admin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Restaurant_Admin/Create

        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                restaurant.Id = Guid.NewGuid();
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        //
        // POST: /Restaurant_Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        //
        // POST: /Restaurant_Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
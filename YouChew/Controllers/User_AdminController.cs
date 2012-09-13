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
    public class User_AdminController : Controller
    {
        private SiteContext db = new SiteContext();

        //
        // GET: /User_Admin/

        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        //
        // GET: /User_Admin/Details/5

        public ActionResult Details(Guid id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /User_Admin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User_Admin/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
			try
			{
				if (ModelState.IsValid)
				{
					user.Id = Guid.NewGuid();
					db.Users.Add(user);
					db.SaveChanges();
					return RedirectToAction("Index");
				}
			}
			catch(DataException)
			{
				ModelState.AddModelError("","Unable to save any changes made. Try again.");
			}
        	return View(user);
        }
      
        //
        // POST: /User_Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
			try
			{
				if (ModelState.IsValid)
				{
					db.Entry(user).State = EntityState.Modified;
					db.SaveChanges();
					return RedirectToAction("Index");
				}
			}
			catch(DataException)
			{
				ModelState.AddModelError("","Unable to save any changes. Try again.");
			}
        	return View(user);
        }

        //
        // POST: /User_Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
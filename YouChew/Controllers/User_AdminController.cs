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
        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /User_Admin/

        public ActionResult Index()
        {
        	
        	return View(unitOfWork.UserRepository.Get().ToList());
        }

        //
        // GET: /User_Admin/Details/5

        public ActionResult Details(Guid id)
        {
        	return View(unitOfWork.UserRepository.GetByID(id));
			
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
        	user.Role = 1;
        	user.score = 0.0;
        	user.joinDate = DateTime.Now;
			try
			{
				if (ModelState.IsValid)
				{
					unitOfWork.UserRepository.Insert(user);
					unitOfWork.Save();
					return RedirectToAction("Index");
				}
			}
			catch(DataException ex)
			{
				ModelState.AddModelError("","Unable to save any changes made. Try again.");
				Console.WriteLine(ex.ToString());
			}
        	return View(user);
        }

		public ActionResult Edit(Guid id)
		{
			return View(unitOfWork.UserRepository.GetByID(id));
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
					unitOfWork.UserRepository.Update(user);
					unitOfWork.Save();
					return RedirectToAction("Index");
				}
			}
			catch(DataException)
			{
				ModelState.AddModelError("","Unable to save any changes. Try again.");
			}
        	return View(user);
        }

		public ActionResult Delete(Guid id)
		{
			return View(unitOfWork.UserRepository.GetByID(id));
		}

        //
        // POST: /User_Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
				unitOfWork.UserRepository.Delete(id);
				unitOfWork.Save();
				return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
           unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
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

		public ActionResult RestaurantViewer()
		{
			return View();
		}

		[HttpGet]
		public ActionResult VenuesLocalSearch(string longitude, string latitude)
		{

			WebClient webClient = new WebClient();
			POSTRequest reqData = new POSTRequest();
			string getRequest = reqData.categoryUrl +"?ll="+longitude+","+latitude+ reqData.authUrlClient + reqData.authUrlClientSecret;
			webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
			string responseArray = webClient.DownloadString(getRequest);
			//JObject o = JObject.Parse(responseArray);
			var jss = new JavaScriptSerializer();

			var parsejson = jss.Deserialize<Category>(responseArray);
			System.Diagnostics.Debug.WriteLine(parsejson);

			return View();
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
			try
			{


				if (ModelState.IsValid)
				{
					restaurant.Id = Guid.NewGuid();
					db.Restaurants.Add(restaurant);
					db.SaveChanges();
					return RedirectToAction("Index");
				}
			}
			catch(DataException)
			{
				ModelState.AddModelError("","Unable to save any changes made. Try again.");
			}

        	return View(restaurant);
        }

        //
        // POST: /Restaurant_Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
			try
			{
				if (ModelState.IsValid)
				{
					db.Entry(restaurant).State = EntityState.Modified;
					db.SaveChanges();
					return RedirectToAction("Index");
				}
			}
			catch(DataException)
			{
				ModelState.AddModelError("", "Unable to save any changes made. Try again.");
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
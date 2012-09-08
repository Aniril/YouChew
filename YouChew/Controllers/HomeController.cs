using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YouChew.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Welcome to YouChew, a place to talk about food";

			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Simple about section will include contributing developers";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Include contact stuff here";

			return View();
		}
	}
}

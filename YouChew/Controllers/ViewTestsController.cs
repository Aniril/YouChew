using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YouChew.Controllers
{
    public class ViewTestsController : Controller
    {
        //
        // GET: /ViewTests/

        public ActionResult MapsTest(string latitude, string longitude)
        {
            ViewBag.Message = "This is a page for testing things. Do not be afraid.";
            
            ViewBag.Latitude = latitude;
            ViewBag.Longitude = longitude;

            return View();
        }

    }
}

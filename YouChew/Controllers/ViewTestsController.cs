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

        public ActionResult MapsTest()
        {
            ViewBag.Message = "This is a page for testing things. Do not be afraid.";
            
            return View();
        }

    }
}

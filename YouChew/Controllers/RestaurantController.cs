using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouChew.Models;

namespace YouChew.Controllers
{
    public class RestaurantController : Controller
    {
        //
        // GET: /Restaurant/

        public ActionResult Restaurant()
        {
            Restaurant tempRes = new Restaurant();
            tempRes.name = "Kentucky Fried Chicken";
            tempRes.phone = "(555)555-5555";
            tempRes.cuisine = "Delicious Chicken";

            return View("Restaurant", tempRes);
        }

    }
}

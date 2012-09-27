using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouChew.Models;
using YouChew.Models.ORM;

namespace YouChew.Controllers
{
    public class RestaurantController : Controller
    {
        //
        // GET: /Restaurant/

        UnitOfWork uow = new UnitOfWork();

        
        public ActionResult Restaurant()
        {
            IEnumerable<Restaurant> stuff =  uow.RestaurantRepository.Get();

            return View(stuff.First());
        }

        public ActionResult RestaurantList()
        {
            IEnumerable<Restaurant> stuff = uow.RestaurantRepository.Get();

            return View(stuff);
        }

    }
}

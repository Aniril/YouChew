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

        public ActionResult Geolocator()
        {
            return View();
        }

		public ActionResult Critiques(Guid id)
		{
			IEnumerable<Critique> morestuff = uow.CritiqueRepository.Get(crit => crit.restaurant != null );

			// Gets critiques for whatever restaurant you select
			//IEnumerable<Critique> morestuff2 = uow.CritiqueRepository.Get().Where(x => x.restaurant.Id == id);
			return View(morestuff);
		}
    }
}

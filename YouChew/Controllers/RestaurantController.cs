using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouChew.Models;
using YouChew.Models.ORM;
using System.Net;
using Newtonsoft.Json.Linq;

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

        [HttpPost]
        public ActionResult Geolocator(string latitude, string longitude)
        {
            ViewBag.Lat = latitude;
            ViewBag.Lng = longitude;

            WebClient webClient = new WebClient();
            POSTRequest reqData = new POSTRequest();
            string getRequest = reqData.searchUrl + "?ll=" + latitude + "," + longitude + reqData.authUrlClient + reqData.authUrlClientSecret;
            webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            string responseArray = webClient.DownloadString(getRequest);
            var root = JObject.Parse(responseArray);
            IEnumerable<JToken> search = new List<JToken>();
            search = root["response"]["groups"][0]["items"];
            List<Restaurant> subsearch = new List<Restaurant>();

            for (int i = 0; i < search.Count(); i++)
            {
                subsearch.Add(new Restaurant
                {
                    //Id = (int)root["response"]["categories"][2]["categories"][i]["id"],
                    name = (string)root["response"]["groups"][0]["items"][i]["venue"]["name"],
                    latitude = (float)root["response"]["groups"][0]["items"][i]["venue"]["location"]["lat"],
                    longitude = (float)root["response"]["groups"][0]["items"][i]["venue"]["location"]["lng"],
                    location = (string)root["response"]["groups"][0]["items"][i]["venue"]["location"]["city"] + ", " + (string)root["response"]["groups"][0]["items"][i]["venue"]["location"]["state"],
                    phone = (string)root["response"]["groups"][0]["items"][i]["venue"]["contact"]["formattedPhone"]
                });
            }
            return View(subsearch);
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

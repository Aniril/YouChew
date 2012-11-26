using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouChew.Models;
using YouChew.Models.ORM;
using System.Net;
using Newtonsoft.Json.Linq;
using YouChew.Services;

namespace YouChew.Controllers
{
    public class RestaurantController : Controller
    {
        //
        // GET: /Restaurant/

        UnitOfWork uow = new UnitOfWork();


        /*public ActionResult Restaurant(string venueId)
        {
            //IEnumerable<Restaurant> stuff =  uow.RestaurantRepository.Get();
        
        }
         */ 
		public ActionResult Restaurant(string venueId)
		{
            var request = new FourSquareRequest();
            var root = JObject.Parse(request.VenueById(venueId));
            IEnumerable<JToken> venueProperties = new List<JToken>();
            Restaurant venue = new Restaurant();

            venue.Id = (string)root["response"]["venue"]["id"];
            venue.name = (string)root["response"]["venue"]["name"];
            venue.address = (string)root["response"]["venue"]["location"]["address"];
            venue.location = (string)root["response"]["venue"]["location"]["city"] + ", " + (string)root["response"]["venue"]["location"]["state"];
            venue.phone = (string)root["response"]["venue"]["contact"]["formattedPhone"];
            venue.website = (string)root["response"]["venue"]["url"];
            try
            {
                int count = (int)root["response"]["venue"]["photos"]["groups"][1]["count"];
                for (int i = 0; i < count; i++)
                {
                    venue.icon = venue.icon + (string)root["response"]["venue"]["photos"]["groups"][1]["items"][i]["url"] + ",";
                }
            }
            catch
            {
            }
            //venue.icon = (string)root["response"]["venue"]["photos"]["groups"][1]["items"][0]["url"];
            venue.latitude = (float)root["response"]["venue"]["location"]["lat"];
            venue.longitude = (float)root["response"]["venue"]["location"]["lng"];

			return View(venue);
		}
        public ActionResult RestaurantList()
        {
            IEnumerable<Restaurant> stuff = uow.RestaurantRepository.Get();

            return View(stuff);
        }

        [HttpPost]
        public ActionResult RestaurantList(string city, string name, string fastFood, string mexican, string pizza)
        {
            List<Restaurant> subsearch = new List<Restaurant>();
            
            if (name == null)
            {
                var request = new FourSquareRequest();
                var root = JObject.Parse(request.VenuesByCity(city));
                IEnumerable<JToken> search = new List<JToken>();
                search = root["response"]["groups"][0]["items"];

                for (int i = 0; i < search.Count(); i++)
                {
                    if ((string)root["response"]["groups"][0]["items"][i]["venue"]["categories"][0]["shortName"] == "Fast Food")
                    {
                        if (fastFood == "on")
                        {
                            subsearch.Add(new Restaurant
                            {
                                Id = (string)root["response"]["groups"][0]["items"][i]["venue"]["id"],
                                name = (string)root["response"]["groups"][0]["items"][i]["venue"]["name"],
                                latitude = (float)root["response"]["groups"][0]["items"][i]["venue"]["location"]["lat"],
                                longitude = (float)root["response"]["groups"][0]["items"][i]["venue"]["location"]["lng"],
                                location = (string)root["response"]["groups"][0]["items"][i]["venue"]["location"]["city"] + ", " + (string)root["response"]["groups"][0]["items"][i]["venue"]["location"]["state"],
                                phone = (string)root["response"]["groups"][0]["items"][i]["venue"]["contact"]["formattedPhone"],
                                icon = (string)root["response"]["groups"][0]["items"][i]["venue"]["categories"][0]["icon"],
                                cuisine = (string)root["response"]["groups"][0]["items"][i]["venue"]["categories"][0]["shortName"]
                            });
                        }
                    }
                    else if ((string)root["response"]["groups"][0]["items"][i]["venue"]["categories"][0]["shortName"] == "Mexican")
                    {
                        if (mexican == "on")
                        {
                            subsearch.Add(new Restaurant
                            {
                                Id = (string)root["response"]["groups"][0]["items"][i]["venue"]["id"],
                                name = (string)root["response"]["groups"][0]["items"][i]["venue"]["name"],
                                latitude = (float)root["response"]["groups"][0]["items"][i]["venue"]["location"]["lat"],
                                longitude = (float)root["response"]["groups"][0]["items"][i]["venue"]["location"]["lng"],
                                location = (string)root["response"]["groups"][0]["items"][i]["venue"]["location"]["city"] + ", " + (string)root["response"]["groups"][0]["items"][i]["venue"]["location"]["state"],
                                phone = (string)root["response"]["groups"][0]["items"][i]["venue"]["contact"]["formattedPhone"],
                                icon = (string)root["response"]["groups"][0]["items"][i]["venue"]["categories"][0]["icon"],
                                cuisine = (string)root["response"]["groups"][0]["items"][i]["venue"]["categories"][0]["shortName"]
                            });
                        }
                    }
                    else if ((string)root["response"]["groups"][0]["items"][i]["venue"]["categories"][0]["shortName"] == "Pizza")
                    {
                        if (pizza == "on")
                        {
                            subsearch.Add(new Restaurant
                            {
                                Id = (string)root["response"]["groups"][0]["items"][i]["venue"]["id"],
                                name = (string)root["response"]["groups"][0]["items"][i]["venue"]["name"],
                                latitude = (float)root["response"]["groups"][0]["items"][i]["venue"]["location"]["lat"],
                                longitude = (float)root["response"]["groups"][0]["items"][i]["venue"]["location"]["lng"],
                                location = (string)root["response"]["groups"][0]["items"][i]["venue"]["location"]["city"] + ", " + (string)root["response"]["groups"][0]["items"][i]["venue"]["location"]["state"],
                                phone = (string)root["response"]["groups"][0]["items"][i]["venue"]["contact"]["formattedPhone"],
                                icon = (string)root["response"]["groups"][0]["items"][i]["venue"]["categories"][0]["icon"],
                                cuisine = (string)root["response"]["groups"][0]["items"][i]["venue"]["categories"][0]["shortName"]
                            });
                        }
                    }
                    else
                    {
                        subsearch.Add(new Restaurant
                        {
                            Id = (string)root["response"]["groups"][0]["items"][i]["venue"]["id"],
                            name = (string)root["response"]["groups"][0]["items"][i]["venue"]["name"],
                            latitude = (float)root["response"]["groups"][0]["items"][i]["venue"]["location"]["lat"],
                            longitude = (float)root["response"]["groups"][0]["items"][i]["venue"]["location"]["lng"],
                            location = (string)root["response"]["groups"][0]["items"][i]["venue"]["location"]["city"] + ", " + (string)root["response"]["groups"][0]["items"][i]["venue"]["location"]["state"],
                            phone = (string)root["response"]["groups"][0]["items"][i]["venue"]["contact"]["formattedPhone"],
                            icon = (string)root["response"]["groups"][0]["items"][i]["venue"]["categories"][0]["icon"],
                            cuisine = (string)root["response"]["groups"][0]["items"][i]["venue"]["categories"][0]["shortName"]
                        });
                    }
                }
            }

            if (city == null)
            {
                var request = new FourSquareRequest();
                var root = JObject.Parse(request.VenuesByName(name));
                IEnumerable<JToken> search = new List<JToken>();
                search = root["response"]["groups"][0]["items"];

                for (int i = 0; i < search.Count(); i++)
                {
                    subsearch.Add(new Restaurant
                    {
                        Id = (string)root["response"]["groups"][0]["items"][i]["venue"]["id"],
                        name = (string)root["response"]["groups"][0]["items"][i]["venue"]["name"],
                        latitude = (float)root["response"]["groups"][0]["items"][i]["venue"]["location"]["lat"],
                        longitude = (float)root["response"]["groups"][0]["items"][i]["venue"]["location"]["lng"],
                        location = (string)root["response"]["groups"][0]["items"][i]["venue"]["location"]["city"] + ", " + (string)root["response"]["groups"][0]["items"][i]["venue"]["location"]["state"],
                        phone = (string)root["response"]["groups"][0]["items"][i]["venue"]["contact"]["formattedPhone"],
                        icon = (string)root["response"]["groups"][0]["items"][i]["venue"]["categories"][0]["icon"],
                        cuisine = (string)root["response"]["groups"][0]["items"][i]["venue"]["categories"][0]["shortName"]
                    });
                }
            }

            return View(subsearch);
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

			var request = new FourSquareRequest();
            var root = JObject.Parse(request.VenuesOrByName(latitude,longitude));
            IEnumerable<JToken> search = new List<JToken>();
            search = root["response"]["groups"][0]["items"];
            List<Restaurant> subsearch = new List<Restaurant>();

            for (int i = 0; i < search.Count(); i++)
            {
                subsearch.Add(new Restaurant
                {
                    Id = (string)root["response"]["groups"][0]["items"][i]["venue"]["id"],
                    name = (string)root["response"]["groups"][0]["items"][i]["venue"]["name"],
                    latitude = (float)root["response"]["groups"][0]["items"][i]["venue"]["location"]["lat"],
                    longitude = (float)root["response"]["groups"][0]["items"][i]["venue"]["location"]["lng"],
                    location = (string)root["response"]["groups"][0]["items"][i]["venue"]["location"]["city"] + ", " + (string)root["response"]["groups"][0]["items"][i]["venue"]["location"]["state"],
                    phone = (string)root["response"]["groups"][0]["items"][i]["venue"]["contact"]["formattedPhone"],
                    icon = (string)root["response"]["groups"][0]["items"][i]["venue"]["categories"][0]["icon"]
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

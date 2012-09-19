using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using YouChew.Models;

namespace YouChew.Models.ORM
{
	public class SiteInit : DropCreateDatabaseIfModelChanges<SiteContext>
	{
		protected override void Seed(SiteContext context)
		{
			var users = new List<User>
			            	{
			            		new User()
			            			{
			            				address = "Test Address 1",
			            				email = "testemail1",
			            				joinDate = DateTime.Now,
			            				username = "Username1",
			            				password = "Password!",
			            			},
			            		new User()
			            			{
			            				address = "Test Address 2",
			            				email = "testemail2",
			            				joinDate = DateTime.Now,
			            				username = "Username2",
			            				password = "Password!"
			            			},
			            		new User()
			            			{
			            				address = "Test Address 3",
			            				email = "testemail3",
			            				joinDate = DateTime.Now,
			            				username = "Username3",
			            				password = "Password!"
			            			}
			            	};
			users.ForEach(s => context.Users.Add(s));
			context.SaveChanges();

			var restaurants = new List<Restaurant>
			                  	{
			                  		new Restaurant()
			                  			{
			                  				addDate = DateTime.Now,
			                  				cuisine = "french",
			                  				name = "French Restaurant",
			                  				location = "US",
			                  				phone = "555-314-4352"
			                  			},
										new Restaurant()
			                  			{
			                  				addDate = DateTime.Now,
			                  				cuisine = "mexican",
			                  				name = "Mexican Restaurant",
			                  				location = "US",
			                  				phone = "555-314-4352"
			                  			},
										new Restaurant()
			                  			{
			                  				addDate = DateTime.Now,
			                  				cuisine = "japanese",
			                  				name = "Japanese Restaurant",
			                  				location = "US",
			                  				phone = "555-314-4352"
			                  			}
			                  	};
			restaurants.ForEach(s => context.Restaurants.Add(s));
			context.SaveChanges();

			var critiques = new List<Critique>
			                	{
			                		new Critique()
			                			{
			                				postDate = DateTime.Now,
			                				rating = 4,
			                				restaurant = restaurants.First(),
			                				review = "Good",
			                				title = "Not a bad place",
			                				user = users.First(),
			                			},
			                		new Critique()
			                			{
			                				postDate = DateTime.Now,
			                				rating = 3,
			                				restaurant = restaurants.First(),
			                				review = "Decent",
			                				title = "Alright Place",
			                				user = users.Last()
			                			}
			                	};
			critiques.ForEach(s => context.Critiques.Add(s));
			context.SaveChanges();

			
		}

		

	}
}
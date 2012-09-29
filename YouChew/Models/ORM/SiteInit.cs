using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
			            				Role = 1
			            			},
			            		new User()
			            			{
			            				address = "Test Address 2",
			            				email = "testemail2",
			            				joinDate = DateTime.Now,
			            				username = "Username2",
			            				password = "Password!",
			            				Role = 1
			            			},
			            		new User()
			            			{
			            				address = "Test Address 3",
			            				email = "testemail3",
			            				joinDate = DateTime.Now,
			            				username = "Username3",
			            				password = "Password!",
			            				Role = 1
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
			                  				phone = "5553144352"
			                  			},
			                  		new Restaurant()
			                  			{
			                  				addDate = DateTime.Now,
			                  				cuisine = "mexican",
			                  				name = "Mexican Restaurant",
			                  				location = "US",
			                  				phone = "5553144352"
			                  			},
			                  		new Restaurant()
			                  			{
			                  				addDate = DateTime.Now,
			                  				cuisine = "japanese",
			                  				name = "Japanese Restaurant",
			                  				location = "US",
			                  				phone = "5553144352"
			                  			}
			                  	};
			restaurants.ForEach(s => context.Restaurants.Add(s));
			try
			{
				context.SaveChanges();
			}
			catch(DbEntityValidationException ex)
			{
				StringBuilder sb = new StringBuilder();

				foreach (var failure in ex.EntityValidationErrors)
				{
					sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());

					foreach (var error in failure.ValidationErrors)
					{
						sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
						sb.AppendLine();
					}
				}

			throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb.ToString());
			}

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


			var roles = new List<Role>
			            	{
			            		new Role()
			            			{
			            				Id = 1,
			            				userguid = users.First().Id,
			            				name = "testrole"
			            			}
			            	};
			roles.ForEach(s => context.Roles.Add(s));
			context.SaveChanges();
		}
	}
}
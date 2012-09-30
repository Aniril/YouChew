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
	public class SiteInit : DropCreateDatabaseAlways<SiteContext>
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
			            				username = "User1",
			            				password = "password",
			            				Role = 1
			            			},
			            		new User()
			            			{
			            				address = "Test Address 2",
			            				email = "testemail2",
			            				joinDate = DateTime.Now,
			            				username = "User2",
			            				password = "password",
			            				Role = 1
			            			},
			            		new User()
			            			{
			            				address = "Test Address 3",
			            				email = "testemail3",
			            				joinDate = DateTime.Now,
			            				username = "User3",
			            				password = "password",
										Role = 1
			            			}
			            	};
			User admin = new User()
			             	{
			             		address = "Admin",
			             		email = "Admin",
			             		username = "Admin",
			             		password = "Password!",
								joinDate = DateTime.Now
			             	};
			users.ForEach(s => context.Users.Add(s));
			context.Users.Add(admin);
			context.SaveChanges();

			Guid[] guids = new Guid[3];
			int i = 0;
			foreach (User x in users)
			{
				guids[i] = x.Id;
				i++;
			}


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
			            			Id = 2,
			            			userguid = admin.Id,
			            			name = "Admin"
			            			},
			            	new Role()
			            		{
			            			Id = 1,
									userguid = guids[0],
									name = "User"
			            		},
							new Role()
			            		{
			            			Id = 1,
									userguid = guids[1],
									name = "User"
			            		},
							new Role()
			            		{
			            			Id = 1,
									userguid = guids[2],
									name = "User"
			            		}
			            	};
			roles.ForEach(s => context.Roles.Add(s));
			context.SaveChanges();
		}
	}
}
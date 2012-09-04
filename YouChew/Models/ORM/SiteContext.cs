using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using YouChew.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace YouChew.Models.ORM
{
	public class SiteContext : DbContext
	{
		public DbSet<Restaurant> Restaurants { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Critique> Critiques { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
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
		public DbSet<UserProfile> UserProfiles { get; set; }
		public DbSet<Restaurant> Restaurants { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Critique> Critiques { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().Property(t => t.username).HasMaxLength(25).IsRequired();
			modelBuilder.Entity<User>().Property(t => t.email).HasMaxLength(50).IsRequired();
			modelBuilder.Entity<User>().Property(t => t.password).HasMaxLength(20).IsRequired();
			modelBuilder.Entity<User>().Property(t => t.address).HasMaxLength(100);
			modelBuilder.Entity<User>().HasMany(t => t.critiques);

			modelBuilder.Entity<Restaurant>().Property(t => t.cuisine).HasMaxLength(20);
			modelBuilder.Entity<Restaurant>().Property(t => t.name).HasMaxLength(100).IsRequired();
			modelBuilder.Entity<Restaurant>().Property(t => t.phone).HasMaxLength(11);
			modelBuilder.Entity<Restaurant>().HasMany(t => t.critiques);

			modelBuilder.Entity<Critique>().HasRequired(t => t.user);
			modelBuilder.Entity<Critique>().HasRequired(t => t.restaurant);
			modelBuilder.Entity<Critique>().Property(t => t.title).IsRequired();
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
namespace YouChew.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using YouChew.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<YouChew.Models.ORM.SiteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(YouChew.Models.ORM.SiteContext context)
        {
        	//  This method will be called after migrating to the latest version.
        	//  You can use the DbSet<T>.AddOrUpdate() helper extension method 

        }
    }
}

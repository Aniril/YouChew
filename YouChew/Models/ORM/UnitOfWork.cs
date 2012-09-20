using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouChew.Models.ORM
{
	public class UnitOfWork : IDisposable
	{
		private SiteContext context = new SiteContext();
		private GenericRepository<User> userRepo;
		private GenericRepository<Restaurant> restaurantRepo;
		private GenericRepository<Critique> critiqueRepo;
		//private Repository to implement <User> and <Role>

		public GenericRepository<User> UserRepository
		{
			get
			{
				if (this.userRepo == null)
				{
					this.userRepo = new GenericRepository<User>(context);
				}
				return userRepo;
			}
		}

		public GenericRepository<Restaurant> RestaurantRepository
		{
			get
			{
				if(this.restaurantRepo == null)
				{
					this.restaurantRepo = new GenericRepository<Restaurant>(context);
				}
				return restaurantRepo;
			}
		}

		public GenericRepository<Critique> CritiqueRepository
		{
			get
			{
				if(this.critiqueRepo == null)
				{
					this.critiqueRepo = new GenericRepository<Critique>(context);
				}
				return critiqueRepo;
			}
		}

		//other repo methods here

		public void Save()
		{
			context.SaveChanges();
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				if(disposing)
				{
					context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
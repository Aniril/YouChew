using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouChew.Models
{
	public class Category
	{
		public Meta Meta { get; set; }
		public VenueResult VenueResult { get; set; }
	}

	public class Meta
	{
		public int code { get; set; }
		public string errorType { get; set; }
		public string errorDetail { get; set; }
	}

	public class VenueResult
	{
		public string id { get; set; }
		public string name { get; set; }
		public string pluralName { get; set; }
		public string shortName { get; set; }
		public string icon { get; set; }
		public VenueResult[] VenueResults { get; set; }
	}

	public class SubCategory
	{
		public VenueResult[] subcategories;
		public PlaceHolderCategory empty { get; set; }
	}

	public class PlaceHolderCategory{}
}
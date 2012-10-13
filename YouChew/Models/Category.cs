using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace YouChew.Models
{
	
	//public class Category
	//{
	//    public Meta Meta { get; set; }
	//    public Response Response{ get; set; }
	//}
	

	//public class Meta
	//{
		
	//    public int code { get; set; }
		
	//    public string errorType { get; set; }
		
	//    public string errorDetail { get; set; }
	//}
	
	//public class Response
	//{
		
	//    public CatArray[] VenueResults { get; set; }
	//}
	
	public class Category
	{
		
		public string id { get; set; }
	
		public string name { get; set; }
		
		public string pluralName { get; set; }
	
		public string shortName { get; set; }
	
		public string icon { get; set; }
		
		public Category[] subCats { get; set; }
	}
}
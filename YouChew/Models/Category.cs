using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace YouChew.Models
{
	public class Category
	{
		
		public string id { get; set; }
	
		public string name { get; set; }
		
		public string pluralName { get; set; }
	
		public string shortName { get; set; }
	
		public string icon { get; set; }
	}
}
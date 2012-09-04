using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouChew.Models
{
	public class User
	{
		public Guid id { get; set; }
		public DateTime joinDate { get; set; }
		public string username { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public double score { get; set; }
		public virtual ICollection<Critique> critiques  { get; set; }
		public string address { get; set; }
	}
}
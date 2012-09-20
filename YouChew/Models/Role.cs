using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouChew.Models
{
	public class Role
	{
		public int ID { get; set; }
		public string name { get; set; }
		public virtual ICollection<User> User { get; set; }
	}
}
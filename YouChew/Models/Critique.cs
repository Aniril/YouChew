using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouChew.Models
{
	public class Critique
	{
		public Guid id { get; set; }
		public DateTime dateTime { get; set; }
		public double? rating { get; set; }
		public string review { get; set; }
		public User user { get; set; }
		public Restaurant restaurant { get; set; }
		public string title { get; set; }
	}
}
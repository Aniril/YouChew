using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace YouChew.Models
{
	public class Critique
	{
		[Key]
		public Guid ID { get; set; }
		public DateTime dateTime { get; set; }
		public double? rating { get; set; }
		public string review { get; set; }
		public User user { get; set; }
		public Restaurant restaurant { get; set; }
		public string title { get; set; }
	}
}
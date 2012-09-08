using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YouChew.Models
{
	public class Restaurant
	{
		[Key]
		public Guid ID { get; set; }
		public DateTime addDate { get; set; }
		public string name { get; set; }
		public string cuisine { get; set; }
		public string location { get; set; }
		public virtual ICollection<Critique> critiques { get; set; }
		public string phone { get; set; }
	}
}
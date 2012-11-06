using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YouChew.Models
{
	public class Restaurant
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }
		public DateTime addDate { get; set; }
		public string name { get; set; }
		public string cuisine { get; set; }
		public string location { get; set; }
		public virtual ICollection<Critique> critiques { get; set; }
		public string phone { get; set; }
		public int likes { get; set; }
		public int plusone { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
		public string icon { get; set; }
	}
}
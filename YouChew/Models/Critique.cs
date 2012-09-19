using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace YouChew.Models
{
	public class Critique
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		public DateTime postDate { get; set; }
		public double? rating { get; set; }
		public string review { get; set; }
		public virtual User user { get; set; }
		public virtual Restaurant restaurant { get; set; }
		public string title { get; set; }
		public bool isShared { get; set; }
	}
}
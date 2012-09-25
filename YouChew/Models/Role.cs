using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YouChew.Models
{
	public class Role
	{
		public int Id { get; set; }
		public string name { get; set; }
		public Guid userguid { get; set; }
	}
}
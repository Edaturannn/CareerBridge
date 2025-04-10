using System;
using System.ComponentModel.DataAnnotations;

namespace Website.Entities.Concrete
{
	public class Class
	{
		[Key]
		public int ClassId { get; set; }

		public string? ClassName { get; set; }
    }
}


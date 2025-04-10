using System;
using System.ComponentModel.DataAnnotations;

namespace Website.Entities.Concrete
{
	public class Departmant
	{
		[Key]
		public int DepartmantId { get; set; }

		public string? DepartmantName { get; set; }

		public string? DepartmantExplanation { get; set; }

		public string? DepartmantImg { get; set; }
    }
}


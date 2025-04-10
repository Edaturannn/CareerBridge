using System;
using Website.Entities.Concrete;

namespace Website.WebUI.Areas.User.Models
{
	public class UserProfileViewModel
	{
		public Website.Entities.Concrete.User User { get; set; }

        public List<Departmant> Departmants { get; set; }

		public List<Class> Classes { get; set; }

    }
}


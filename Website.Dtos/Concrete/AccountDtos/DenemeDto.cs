using System;
namespace Website.Dtos.Concrete.AccountDtos
{
	public class DenemeDto
	{
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }


        // Users Sayfasında Profile Sayfasında boş olan alanlrı içini dolduracak.
        public string Department { get; set; }
        public string Class { get; set; }
        // Users Sayfasında Profile Sayfasında boş olan alanlrı içini dolduracak.
    }
}


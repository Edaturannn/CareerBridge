﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Hosting;

namespace Website.Entities.Concrete
{
	public class User
	{
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; } //Argo2

        public string Role { get; set; } // "Student", "Mentor", "Admin"

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        // Users Sayfasında Profile Sayfasında boş olan alanlrı içini dolduracak.
        public string? Department { get; set; }
        public string? Class { get; set; }
        // Users Sayfasında Profile Sayfasında boş olan alanlrı içini dolduracak.


        public List<Contact> Contacts { get; set; }
    }
}


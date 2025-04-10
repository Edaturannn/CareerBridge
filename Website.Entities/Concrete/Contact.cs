using System;
using System.ComponentModel.DataAnnotations;

namespace Website.Entities.Concrete
{
	public class Contact
	{
		[Key]
		public int ContactId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}


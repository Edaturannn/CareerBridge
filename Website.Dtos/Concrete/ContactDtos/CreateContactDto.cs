using System;
using Website.Entities.Concrete;

namespace Website.Dtos.Concrete.ContactDtos
{
	public class CreateContactDto
	{
        public int UserId { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}


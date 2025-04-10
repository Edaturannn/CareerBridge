using System;
using Website.Entities.Concrete;

namespace Website.Dtos.Concrete.ContactDtos
{
	public class UpdateContactDto
	{
        public int ContactId { get; set; }

        public int UserId { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}


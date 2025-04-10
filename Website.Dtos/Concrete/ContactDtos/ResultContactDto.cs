using System;
using Website.Entities.Concrete;

namespace Website.Dtos.Concrete.ContactDtos
{
	public class ResultContactDto
	{
        public int ContactId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}


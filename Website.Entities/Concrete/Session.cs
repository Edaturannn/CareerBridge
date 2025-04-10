using System;
using System.ComponentModel.DataAnnotations;

namespace Website.Entities.Concrete
{
	public class Session
	{
        [Key]
        public Guid SessionId { get; set; }
        public string Username { get; set; }
      
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}


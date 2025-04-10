using System;
using System.ComponentModel.DataAnnotations;

namespace Website.Entities.Concrete
{
	public class PasswordResetToken
	{
        [Key]
        public int PasswordResetTokenId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}


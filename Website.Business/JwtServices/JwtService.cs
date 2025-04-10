using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Website.Business.JwtServices
{
	public class JwtService : IJwtService
	{
		private readonly IConfiguration _configuration;
		public JwtService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

        public string GenerateToken(string sessionId)
        {
			var jwtSettings = _configuration.GetSection("Jwt");
			var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);
			var issuer = jwtSettings["Issuer"];
			var audience = jwtSettings["audience"];
			var expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiresInMinutes"]));

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, sessionId),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.Name, sessionId)
			};
			var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
					issuer,
					audience,
					claims,
					expires: expires,
					signingCredentials: signingCredentials
				);
			return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}


using System;
namespace Website.Business.JwtServices
{
	public interface IJwtService
	{
		string GenerateToken(string sessionId);
    }
}


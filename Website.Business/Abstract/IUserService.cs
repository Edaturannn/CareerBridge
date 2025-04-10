using System;
using Website.Dtos.Concrete.AccountDtos;
using Website.Entities.Concrete;

namespace Website.Business.Abstract
{
	public interface IUserService : IGenericService<User>
	{
		Task<bool> RegisterUserAsync(RegisterDto registerDto);
		Task<LoginResultDto?> LoginUserAsync(LoginDto loginDto);
    }
}


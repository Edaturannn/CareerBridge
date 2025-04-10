using System;
using Website.Entities.Concrete;

namespace Website.DataAccess.Abstract
{
	public interface IUserDal : IGenericDal<User>
	{
        Task<bool> UserExistsAsync(string username);

        Task<string?> GetPasswordHashAsync(string username);
        User? GetUserByUsername(string username);
    }
}


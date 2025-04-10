using System;
using Microsoft.EntityFrameworkCore;
using Website.DataAccess.Abstract;
using Website.DataAccess.Concrete;
using Website.DataAccess.Repositories;
using Website.Entities.Concrete;

namespace Website.DataAccess.EntityFramework
{
    public class EFUserDal : GenericRepository<User>, IUserDal
    {
        private readonly Context _context;
        public EFUserDal(Context context) : base(context)
        {
            _context = context;
        }
        public async Task<string?> GetPasswordHashAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.FullName == username);
            return user?.PasswordHash;
        }

        public User? GetUserByUsername(string username)
        {
            var user = _context.Users.Where(x => x.FullName == username).FirstOrDefault();
            return user;
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            return await _context.Users.AnyAsync(x => x.FullName == username);
        }
    }
}


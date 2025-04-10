using System;
using Microsoft.EntityFrameworkCore;
using Website.DataAccess.Abstract;
using Website.DataAccess.Concrete;
using Website.DataAccess.Repositories;
using Website.Entities.Concrete;

namespace Website.DataAccess.EntityFramework
{
	public class EFContactDal : GenericRepository<Contact>, IContactDal
	{
        private readonly Context _context;
        public EFContactDal(Context context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Contact>> GetAllUserId(int userId)
        {
            using var context = new Context();
            return await context.Contacts.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}


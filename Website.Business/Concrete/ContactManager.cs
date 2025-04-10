using System;
using Website.Business.Abstract;
using Website.DataAccess.Abstract;
using Website.Entities.Concrete;

namespace Website.Business.Concrete
{
	public class ContactManager : IContactService
	{
		private readonly IContactDal _contactDal;
		public ContactManager(IContactDal contactDal)
		{
			_contactDal = contactDal;
		}

        public async Task TAddAsync(Contact t)
        {
            await _contactDal.AddAsync(t);
        }

        public async Task TDeleteAsync(int id)
        {
            await _contactDal.DeleteAsync(id);
        }

        public async Task<IEnumerable<Contact>> TGetAllAsync()
        {
            return await _contactDal.GetAllAsync();
        }

        public async Task<Contact> TGetByIdAsync(int id)
        {
            return await _contactDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(Contact t)
        {
            await _contactDal.UpdateAsync(t);
        }
    }
}


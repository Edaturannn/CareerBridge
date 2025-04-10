using System;
using Microsoft.EntityFrameworkCore;
using Website.DataAccess.Abstract;
using Website.DataAccess.Concrete;

namespace Website.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly Context Context;
        public GenericRepository(Context context)
        {
            Context = context;
        }
        public async Task AddAsync(T t)
        {
            await Context.Set<T>().AddAsync(t);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var values = await Context.Set<T>().FindAsync(id);
            Context.Set<T>().Remove(values);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var values = await Context.Set<T>().ToListAsync();
            return values;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var values = await Context.Set<T>().FindAsync(id);
            return values;
        }

        public async Task UpdateAsync(T t)
        {
            Context.Set<T>().Update(t);
            await Context.SaveChangesAsync();
        }
    }
}


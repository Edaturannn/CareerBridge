using System;
namespace Website.DataAccess.Abstract
{
	public interface IGenericDal<T> where T : class
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);
		Task AddAsync(T t);
		Task UpdateAsync(T t);
		Task DeleteAsync(int id);
	}
}


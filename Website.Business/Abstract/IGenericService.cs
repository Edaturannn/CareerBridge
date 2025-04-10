using System;
namespace Website.Business.Abstract
{
	public interface IGenericService<T> where T : class
	{
		Task<IEnumerable<T>> TGetAllAsync();
		Task<T> TGetByIdAsync(int id);
		Task TAddAsync(T t);
		Task TUpdateAsync(T t);
		Task TDeleteAsync(int id);
	}
}


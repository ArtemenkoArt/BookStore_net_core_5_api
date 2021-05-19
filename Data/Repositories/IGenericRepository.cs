using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookStore_01.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task Delete(int id);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IList<T>> GetList(Expression<Func<T, bool>> expression);
        Task<T> Update(T entity);
    }
}
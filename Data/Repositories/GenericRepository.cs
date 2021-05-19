using BookStore_01.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookStore_01.Data.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        protected readonly BookStoreContext _context;
        private readonly ILogger _logger;

        public GenericRepository(BookStoreContext context, ILogger<BookStoreContext> logger)
        {
            _context = context;
            _logger = logger;
        }

        public virtual async Task<T> Get(int id)
        {
            try
            {
                var result = await _context.Set<T>().FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GenericRepository.Get(): {0}, Message: {1}", typeof(T).Name, ex.Message));
                return null;
            }
        }

        public virtual async Task<IList<T>> GetList(Expression<Func<T, bool>> expression)
        {
            try
            {
                var result = await _context.Set<T>().Where(expression).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GenericRepository.GetList(): {0}, Message: {1}", typeof(T).Name, ex.Message));
                return null;
            }
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                var result = await _context.Set<T>().ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GenericRepository.GetAll(): {0}, Message: {1}", typeof(T).Name, ex.Message));
                return null;
            }
        }

        public virtual async Task<T> Add(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GenericRepository.Add(): {0}, Message: {1}", typeof(T).Name, ex.Message));
                return null;
            }
        }

        public virtual async Task<T> Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GenericRepository.Update(): {0}, Message: {1}", typeof(T).Name, ex.Message));
                return null;
            }
        }

        public virtual async Task Delete(int id)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("GenericRepository.Delete(): {0}, Message: {1}", typeof(T).Name, ex.Message));
            }
        }

    }
}

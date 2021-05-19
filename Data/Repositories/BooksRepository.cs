using BookStore_01.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_01.Data.Repositories
{
    public class BooksRepository : GenericRepository<Book>, IBooksRepository
    {
        private ILogger<BookStoreContext> logger { get; }
        public BooksRepository(BookStoreContext context, ILogger<BookStoreContext> logger) : base(context, logger)
        {
            this.logger = logger;
        }

        public override async Task<Book> Get(int id)
        {
            try
            {
                var result = await _context.Set<Book>().Include(c => c.Authors).FirstOrDefaultAsync(c => c.Id == id);
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(string.Format("GenericRepository.Get(): {0}, Message: {1}", typeof(Book).Name, ex.Message));
                return null;
            }
        }

        public override async Task<IEnumerable<Book>> GetAll()
        {
            try
            {
                var result = await _context.Set<Book>().Include(c => c.Authors).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(string.Format("GenericRepository.GetAll(): {0}, Message: {1}", typeof(Book).Name, ex.Message));
                return null;
            }
        }

        public override async Task<Book> Add(Book entity)
        {
            try
            {
                _context.Set<Book>();
                foreach (var author in entity.Authors)
                    _context.Attach(author);

                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                logger.LogError(string.Format("GenericRepository.Add(): {0}, Message: {1}", typeof(Book).Name, ex.Message));
                return null;
            }
        }

        public override async Task<Book> Update(Book entity)
        {
            try
            {
                _context.Set<Book>();
                foreach (var author in entity.Authors)
                    _context.Attach(author);

                var toBeUpdated = await _context.Books.Include(c => c.Authors).FirstOrDefaultAsync(c => c.Id == entity.Id);
                if (toBeUpdated != null)
                {
                    toBeUpdated.Authors.Clear();
                    toBeUpdated.Title = entity.Title;

                    if (entity.Authors.Count > 0)
                    {
                        foreach (var author in entity.Authors)
                            toBeUpdated.Authors.Add(author);
                    }

                    _context.Update(toBeUpdated);
                    await _context.SaveChangesAsync();
                    return entity;
                }
                logger.LogError(string.Format("GenericRepository.Update(): {0}", typeof(Book).Name));
                return null;

            }
            catch (Exception ex)
            {
                logger.LogError(string.Format("GenericRepository.Update(): {0}, Message: {1}", typeof(Book).Name, ex.Message));
                return null;
            }
        }
    }
}
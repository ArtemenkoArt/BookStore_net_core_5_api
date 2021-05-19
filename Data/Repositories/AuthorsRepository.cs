using BookStore_01.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_01.Data.Repositories
{
    public class AuthorsRepository : GenericRepository<Author>, IAuthorsRepository
    {
        private ILogger<BookStoreContext> logger { get; }
        public AuthorsRepository(BookStoreContext context, ILogger<BookStoreContext> logger) : base(context, logger)
        {
            this.logger = logger;
        }

        public override async Task<Author> Get(int id)
        {
            try
            {
                var result = await _context.Set<Author>().Include(c => c.Books).FirstOrDefaultAsync(c => c.Id == id);
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(string.Format("GenericRepository.Get(): {0}, Message: {1}", typeof(Author).Name, ex.Message));
                return null;
            }
        }

        public override async Task<IEnumerable<Author>> GetAll()
        {
            try
            {
                var result = await _context.Set<Author>().Include(c => c.Books).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(string.Format("GenericRepository.GetAll(): {0}, Message: {1}", typeof(Author).Name, ex.Message));
                return null;
            }
        }

        public override async Task<Author> Add(Author entity)
        {
            try
            {
                _context.Set<Author>();
                foreach (var book in entity.Books)
                    _context.Attach(book);

                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                logger.LogError(string.Format("GenericRepository.Add(): {0}, Message: {1}", typeof(Author).Name, ex.Message));
                return null;
            }
        }

        public override async Task<Author> Update(Author entity)
        {
            try
            {
                _context.Set<Author>();
                foreach (var book in entity.Books)
                    _context.Attach(book);

                var toBeUpdated = await _context.Authors.Include(c => c.Books).FirstOrDefaultAsync(c => c.Id == entity.Id);
                if (toBeUpdated != null)
                {
                    toBeUpdated.Books.Clear();
                    toBeUpdated.FirstName = entity.FirstName;
                    toBeUpdated.LastName = entity.LastName;

                    if (entity.Books.Count > 0)
                    {
                        foreach (var author in entity.Books)
                            toBeUpdated.Books.Add(author);
                    }

                    _context.Update(toBeUpdated);
                    await _context.SaveChangesAsync();
                    return entity;
                }
                logger.LogError(string.Format("GenericRepository.Update(): {0}", typeof(Author).Name));
                return null;

            }
            catch (Exception ex)
            {
                logger.LogError(string.Format("GenericRepository.Update(): {0}, Message: {1}", typeof(Author).Name, ex.Message));
                return null;
            }
        }
    }
}
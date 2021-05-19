using BookStore_01.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_01.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookStoreContext _context;
        public IAuthorsRepository Authors { get; }
        public IBooksRepository Books { get; }
        public IOrdersRepository Orders { get; }
        public IOrderItemsRepository OrderItems { get; }

        public UnitOfWork(BookStoreContext context,
            IAuthorsRepository authorsRepository,
            IBooksRepository booksRepository,
            IOrdersRepository ordersRepository,
            IOrderItemsRepository orderItemsRepository)
        {
            this._context = context;
            this.Authors = authorsRepository;
            this.Books = booksRepository;
            this.Orders = ordersRepository;
            this.OrderItems = orderItemsRepository;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}

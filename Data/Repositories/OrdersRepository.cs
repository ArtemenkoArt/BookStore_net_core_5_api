using BookStore_01.Data.Entities;
using Microsoft.Extensions.Logging;

namespace BookStore_01.Data.Repositories
{
    public class OrdersRepository : GenericRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(BookStoreContext context, ILogger<BookStoreContext> logger) : base(context, logger)
        {
        }
    }
}
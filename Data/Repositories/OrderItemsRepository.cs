using BookStore_01.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_01.Data.Repositories
{
    public class OrderItemsRepository : GenericRepository<OrderItem>, IOrderItemsRepository
    {
        private ILogger<BookStoreContext> logger { get; }
        public OrderItemsRepository(BookStoreContext context, ILogger<BookStoreContext> logger) : base(context, logger)
        {
            this.logger = logger;
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItems(int orderId)
        {
            try
            {
                var result = await _context.Set<Order>().Include(c => c.Items).ThenInclude(c => c.Book).FirstOrDefaultAsync(c => c.Id == orderId);
                if (result != null)
                    return result.Items;

                return null;
            }
            catch (Exception ex)
            {
                logger.LogError(string.Format("OrderItemsRepository.GetOrderItems(orderId): {0}, Message: {1}", typeof(OrderItem).Name, ex.Message));
                return null;
            }
        }

        public async Task<OrderItem> Get(int orderId, int id)
        {
            try
            {
                var result = await _context.Set<OrderItem>().Include(c => c.Book).FirstOrDefaultAsync(c => c.Order.Id == orderId && c.Id == id);
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(string.Format("OrderItemsRepository.Get(orderId, id): {0}, Message: {1}", typeof(OrderItem).Name, ex.Message));
                return null;
            }
        }
    }
}
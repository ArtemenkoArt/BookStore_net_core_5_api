using BookStore_01.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_01.Data.Repositories
{
    public interface IOrderItemsRepository : IGenericRepository<OrderItem>
    {
        Task<OrderItem> Get(int orderId, int id);
        Task<IEnumerable<OrderItem>> GetOrderItems(int orderId);
    }
}

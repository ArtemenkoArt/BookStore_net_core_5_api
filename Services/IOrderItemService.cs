using BookStore_01.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_01.Services
{
    public interface IOrderItemService
    {
        Task<OrderItemViewModel> Add(OrderItemViewModel viewModel);
        Task Delete(int id);
        Task<OrderItemViewModel> Get(int id);
        Task<IEnumerable<OrderItemViewModel>> GetAll();
        Task<OrderItemViewModel> Update(OrderItemViewModel viewModel);
        Task<IEnumerable<OrderItemViewModel>> GetOrderItems(int orderId);
        Task<OrderItemViewModel> GetOrderItem(int orderId, int itemId);
    }
}
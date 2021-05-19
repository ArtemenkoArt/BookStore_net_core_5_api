using BookStore_01.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_01.Services
{
    public interface IOrderService
    {
        Task<OrderViewModel> Add(OrderViewModel viewModel);
        Task Delete(int id);
        Task<OrderViewModel> Get(int id);
        Task<IEnumerable<OrderViewModel>> GetAll();
        Task<OrderViewModel> Update(OrderViewModel viewModel);
    }
}
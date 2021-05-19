using AutoMapper;
using BookStore_01.Data;
using BookStore_01.Data.Entities;
using BookStore_01.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_01.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderViewModel> Get(int id)
        {
            return _mapper.Map<Order, OrderViewModel>(await _unitOfWork.Orders.Get(id));
        }

        public async Task<IEnumerable<OrderViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<OrderViewModel>>(await _unitOfWork.Orders.GetAll());
        }

        public async Task<OrderViewModel> Add(OrderViewModel viewModel)
        {
            var entity = _mapper.Map<Order>(viewModel);
            await _unitOfWork.Orders.Add(entity);
            return _mapper.Map<Order, OrderViewModel>(entity);
        }

        public async Task<OrderViewModel> Update(OrderViewModel viewModel)
        {
            var entity = _mapper.Map<Order>(viewModel);
            await _unitOfWork.Orders.Update(entity);
            return _mapper.Map<Order, OrderViewModel>(entity);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.Orders.Delete(id);
        }
    }
}

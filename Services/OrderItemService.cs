using AutoMapper;
using BookStore_01.Data;
using BookStore_01.Data.Entities;
using BookStore_01.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_01.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderItemViewModel>> GetOrderItems(int orderId)
        {
            var entity = await _unitOfWork.OrderItems.GetOrderItems(orderId);
            return _mapper.Map<IEnumerable<OrderItemViewModel>>(entity);
        }

        public async Task<OrderItemViewModel> GetOrderItem(int orderId, int itemId)
        {
            var entity = await _unitOfWork.OrderItems.Get(orderId, itemId);
            return _mapper.Map<OrderItem, OrderItemViewModel>(entity);
        }

        public async Task<OrderItemViewModel> Get(int id)
        {
            return _mapper.Map<OrderItem, OrderItemViewModel>(await _unitOfWork.OrderItems.Get(id));
        }

        public async Task<IEnumerable<OrderItemViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<OrderItemViewModel>>(await _unitOfWork.OrderItems.GetAll());
        }

        public async Task<OrderItemViewModel> Add(OrderItemViewModel viewModel)
        {
            var entity = _mapper.Map<OrderItem>(viewModel);
            await _unitOfWork.OrderItems.Add(entity);
            return _mapper.Map<OrderItem, OrderItemViewModel>(entity);
        }

        public async Task<OrderItemViewModel> Update(OrderItemViewModel viewModel)
        {
            var entity = _mapper.Map<OrderItem>(viewModel);
            await _unitOfWork.OrderItems.Update(entity);
            return _mapper.Map<OrderItem, OrderItemViewModel>(entity);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.OrderItems.Delete(id);
        }
    }
}

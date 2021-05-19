using AutoMapper;
using BookStore_01.Data.Entities;
using BookStore_01.Models;

namespace BookStore_01.Data
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Author, AuthorViewModel>().ReverseMap();

            CreateMap<Book, BookViewModel>().ReverseMap();

            CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();

            CreateMap<Order, OrderViewModel>()
                .ForMember(v => v.OrderId, e => e.MapFrom(i => i.Id))
                .ReverseMap();
        }
    }
}

using System;
using System.Collections.Generic;

namespace BookStore_01.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public ICollection<OrderItemViewModel> Items { get; set; }

        public OrderViewModel()
        {
            Items = new List<OrderItemViewModel>();
        }
    }
}

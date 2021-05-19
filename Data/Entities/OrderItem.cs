using System.ComponentModel.DataAnnotations;

namespace BookStore_01.Data.Entities
{
    public class OrderItem : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public Book Book { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Sum { get; set; }
        public Order Order { get; set; }
    }
}

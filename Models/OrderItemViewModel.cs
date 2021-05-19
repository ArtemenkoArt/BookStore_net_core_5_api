using System.ComponentModel.DataAnnotations;

namespace BookStore_01.Models
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        [Required]
        public BookViewModel Book { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal Sum { get; set; }
    }
}

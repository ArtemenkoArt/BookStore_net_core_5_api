using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore_01.Models
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public List<BookViewModel> Books { get; set; }

        public AuthorViewModel()
        {
            Books = new List<BookViewModel>();
        }
    }
}

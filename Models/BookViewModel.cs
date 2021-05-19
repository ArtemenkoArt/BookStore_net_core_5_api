using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore_01.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public List<AuthorViewModel> Authors { get; set; }

        public BookViewModel()
        {
            Authors = new List<AuthorViewModel>();
        }
    }
}

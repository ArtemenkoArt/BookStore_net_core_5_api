using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore_01.Data.Entities
{
    public class Book : IEntity
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Author> Authors { get; set; }

        public Book()
        {
            Authors = new List<Author>();
        }
    }
}

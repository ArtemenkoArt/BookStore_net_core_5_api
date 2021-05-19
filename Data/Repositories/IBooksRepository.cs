using BookStore_01.Data.Entities;
using System.Threading.Tasks;

namespace BookStore_01.Data.Repositories
{
    public interface IBooksRepository : IGenericRepository<Book>
    {
    }
}

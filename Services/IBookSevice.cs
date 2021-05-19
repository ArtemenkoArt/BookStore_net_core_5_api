using BookStore_01.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_01.Services
{
    public interface IBookSevice
    {
        Task<BookViewModel> Add(BookViewModel viewModel);
        Task Delete(int id);
        Task<BookViewModel> Get(int id);
        Task<IEnumerable<BookViewModel>> GetAll();
        Task<BookViewModel> Update(BookViewModel viewModel);
    }
}
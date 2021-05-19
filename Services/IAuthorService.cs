using BookStore_01.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_01.Services
{
    public interface IAuthorService
    {
        Task<AuthorViewModel> Add(AuthorViewModel viewModel);
        Task Delete(int id);
        Task<AuthorViewModel> Get(int id);
        Task<IEnumerable<AuthorViewModel>> GetAll();
        Task<AuthorViewModel> Update(AuthorViewModel viewModel);
    }
}
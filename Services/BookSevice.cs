using AutoMapper;
using BookStore_01.Data;
using BookStore_01.Data.Entities;
using BookStore_01.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_01.Services
{
    public class BookSevice : IBookSevice
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookSevice(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookViewModel> Get(int id)
        {
            return _mapper.Map<Book, BookViewModel>(await _unitOfWork.Books.Get(id));
        }

        public async Task<IEnumerable<BookViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<BookViewModel>>(await _unitOfWork.Books.GetAll());
        }

        public async Task<BookViewModel> Add(BookViewModel viewModel)
        {
            var entity = _mapper.Map<Book>(viewModel);
            await _unitOfWork.Books.Add(entity);
            return _mapper.Map<Book, BookViewModel>(entity);
        }

        public async Task<BookViewModel> Update(BookViewModel viewModel)
        {
            var entity = _mapper.Map<Book>(viewModel);
            await _unitOfWork.Books.Update(entity);
            return _mapper.Map<Book, BookViewModel>(entity);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.Books.Delete(id);
        }
    }
}

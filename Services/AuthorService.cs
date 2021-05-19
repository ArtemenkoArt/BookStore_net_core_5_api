using AutoMapper;
using BookStore_01.Data;
using BookStore_01.Data.Entities;
using BookStore_01.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_01.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AuthorViewModel> Get(int id)
        {
            return _mapper.Map<Author, AuthorViewModel>(await _unitOfWork.Authors.Get(id));
        }

        public async Task<IEnumerable<AuthorViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<AuthorViewModel>>(await _unitOfWork.Authors.GetAll());
        }

        public async Task<AuthorViewModel> Add(AuthorViewModel viewModel)
        {
            var entity = _mapper.Map<Author>(viewModel);
            await _unitOfWork.Authors.Add(entity);
            return _mapper.Map<Author, AuthorViewModel>(entity);
        }

        public async Task<AuthorViewModel> Update(AuthorViewModel viewModel)
        {
            var entity = _mapper.Map<Author>(viewModel);
            await _unitOfWork.Authors.Update(entity);
            return _mapper.Map<Author, AuthorViewModel>(entity);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.Authors.Delete(id);
        }
    }
}

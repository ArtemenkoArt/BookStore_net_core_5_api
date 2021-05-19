using BookStore_01.Data.Repositories;
using System;

namespace BookStore_01.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorsRepository Authors { get; }
        IBooksRepository Books { get; }
        IOrderItemsRepository OrderItems { get; }
        IOrdersRepository Orders { get; }

        int Complete();
    }
}
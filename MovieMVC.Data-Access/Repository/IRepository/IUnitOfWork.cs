using System;

namespace MovieMVC.Data_Access.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        ISP_Call SP_Call { get; }

        void Save();
    }
}

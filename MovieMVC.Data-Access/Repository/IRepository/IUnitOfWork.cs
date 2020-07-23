using System;

namespace MovieMVC.Data_Access.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IDeliveryTypeRepository DeliveryType { get; }

        IMovieRepository Movie { get; }

        ICompanyRepository Company { get; }
        IApplicationUserRepository ApplicationUser { get; }

        IOrderDetailsRepository OrderDetails { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IShoppingCartRepository ShoppingCart { get; }

        ISP_Call SP_Call { get; }

        void Save();
    }
}

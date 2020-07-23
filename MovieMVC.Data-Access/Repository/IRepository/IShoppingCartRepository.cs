using MovieMVC.Model;

namespace MovieMVC.Data_Access.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        void Update(ShoppingCart shopping);
    }
}

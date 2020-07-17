using MovieMVC.Model;

namespace MovieMVC.Data_Access.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}

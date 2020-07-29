using MovieMVC.Model;

namespace MovieMVC.Data_Access.Repository.IRepository
{
    public interface ICategoryRepository : IRepositoryAsync<Category>
    {
        void Update(Category category);
    }
}

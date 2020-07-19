using MovieMVC.Model;

namespace MovieMVC.Data_Access.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company company);
    }
}

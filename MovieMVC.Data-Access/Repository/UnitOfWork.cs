using MovieMVC.Data_Access.Data;
using MovieMVC.Data_Access.Repository.IRepository;
using MovieMVC.Model;

namespace MovieMVC.Data_Access.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            DeliveryType = new DeliveryTypeRepository(_db);
            Movie = new MovieRepository(_db);
            Company = new CompanyRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            SP_Call = new SP_Call(_db);
        }
        public ICategoryRepository Category { get; private set; }

        public IDeliveryTypeRepository DeliveryType { get; private set; }

        public IMovieRepository Movie { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public ISP_Call SP_Call { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

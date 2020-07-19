using MovieMVC.Data_Access.Data;
using MovieMVC.Data_Access.Repository.IRepository;
using MovieMVC.Model;
using System.Linq;

namespace MovieMVC.Data_Access.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public void Update(ApplicationUser applicationUser)
        //{
        //    _db.Update(applicationUser);
        //}
    }
}

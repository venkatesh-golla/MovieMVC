using MovieMVC.Data_Access.Data;
using MovieMVC.Data_Access.Repository.IRepository;
using MovieMVC.Model;
using System.Linq;

namespace MovieMVC.Data_Access.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderHeader obj)
        {
            _db.Update(obj);
        }
    }
}

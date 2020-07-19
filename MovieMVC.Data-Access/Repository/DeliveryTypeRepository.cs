using MovieMVC.Data_Access.Data;
using MovieMVC.Data_Access.Repository.IRepository;
using MovieMVC.Model;
using System.Linq;

namespace MovieMVC.Data_Access.Repository
{
    public class DeliveryTypeRepository : Repository<DeliveryType>, IDeliveryTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public DeliveryTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(DeliveryType deliveryType)
        {

            var objFromDb = _db.DeliveryTypes.FirstOrDefault(s => s.Id == deliveryType.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = deliveryType.Name;
            }
        }
    }
}

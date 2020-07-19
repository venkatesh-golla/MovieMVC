using MovieMVC.Model;

namespace MovieMVC.Data_Access.Repository.IRepository
{
    public interface IDeliveryTypeRepository : IRepository<DeliveryType>
    {
        void Update(DeliveryType deliveryType);
    }
}

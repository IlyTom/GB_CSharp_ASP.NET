using Store.Models.DTO;

namespace Store.Abstraction
{
    public interface IStoreService
    {
        public Guid AddStore(StoreDTO store);
        public Guid DeleteStore(Guid storeId);

        public StoreDTO GetStoreById(Guid storeId);

        public IEnumerable<StoreDTO> GetAllStores();

        public bool StoreExist(Guid storeId);
    }
}

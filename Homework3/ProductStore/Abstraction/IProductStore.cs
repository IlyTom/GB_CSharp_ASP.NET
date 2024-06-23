using ProductStore.Models.DTO;

namespace ProductStore.Abstraction
{
    public interface IProductStore
    {
        public void AddStoreItem(StoreItemDTO item);
        public void RemoveStoreItemQuantity(Guid itemId, decimal quantity);

        public void UpdateStoreItemQuantity(Guid itemId, decimal quantity);

        public IEnumerable<StoreItemDTO> GetStoreItems();

        public IEnumerable<StoreItemDTO> GetStoreItems(Guid storeId);
    } 
}

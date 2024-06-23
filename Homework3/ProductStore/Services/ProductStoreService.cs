using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductStore.Abstraction;
using ProductStore.Models;
using ProductStore.Models.DTO;


namespace ProductStore.Services
{
    public class ProductStoreService : IProductStore
    {
        private IMapper _mapper;
        private ProductStoreContext _context;

        public ProductStoreService(IMapper mapper, ProductStoreContext context)
        {
            _context = context;
            _mapper = mapper;
        }


        public void AddStoreItem([FromQuery]StoreItemDTO item)
        {
            using (_context)
            {
                var entity = _mapper.Map<StoreItem>(item);
                _context.StoreItems.Add(entity);
                _context.SaveChanges();
            }
        }

        public IEnumerable<StoreItemDTO> GetStoreItems()
        {
            using (_context)
            {
                var storesItems = _context.StoreItems.Select(x => _mapper.Map<StoreItemDTO>(x)).ToList();
                return storesItems;
            }
        }

        public IEnumerable<StoreItemDTO> GetStoreItems(Guid storeId)
        {
            var storeItems = _context.StoreItems.Where(x => x.StoreId == storeId).ToList();
            var items = new List<StoreItemDTO>();
            foreach (var storeItem in storeItems) { 
                items.Add(_mapper.Map<StoreItemDTO>(storeItem));
            }
            return items;
        }

        public void RemoveStoreItemQuantity(Guid itemId, decimal quantity)
        {
            using (_context)
            {
                var item = _context.StoreItems.FirstOrDefault(x => x.ItemId == itemId);
                if (item != null)
                {
                    if (item.Quantity >= quantity)
                    {
                        item.Quantity -= quantity;
                        _context.SaveChanges();
                    }
                    else if(item.Quantity < quantity) 
                    {
                        throw new Exception("Недостаточно количества товара");
                    }
                }
            }
        }

        public void UpdateStoreItemQuantity(Guid itemId, decimal quantity)
        {
            using (_context)
            {
                var item = _context.StoreItems.FirstOrDefault(x => x.ItemId == itemId);
                if (item != null)
                {
                    item.Quantity += quantity;
                    _context.SaveChanges();                    
                }
            }
        }
    }
}

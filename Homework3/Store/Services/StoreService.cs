using AutoMapper;
using Store.Abstraction;
using Store.Models;
using Store.Models.DTO;

namespace Store.Services
{
    public class StoreService : IStoreService
    {
        private IMapper _mapper;
        private StoreContext _context;

        public StoreService (IMapper mapper, StoreContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Guid AddStore(StoreDTO store)
        {
            using (_context) { 
                var entity = _mapper.Map<Models.Store>(store);
                _context.Stores.Add(entity);
                _context.SaveChanges();
                return entity.Id;
            }
        }

        public Guid DeleteStore(Guid storeId)
        {
            using (_context)
            {
                var entity = _context.Stores.FirstOrDefault(x => x.Id == storeId);                
                _context.Stores.Remove(entity!);
                _context.SaveChanges();
                return entity.Id;
            }
        }

        public IEnumerable<StoreDTO> GetAllStores()
        {
            using (_context)
            {
                var stores = _context.Stores.Select(x => _mapper.Map<StoreDTO>(x)).ToList();
                return stores;
            }
        }

        public StoreDTO GetStoreById(Guid storeId)
        {
            var entity = _context.Stores.FirstOrDefault(x => x.Id == storeId);
            return _mapper.Map<StoreDTO>(entity);
        }

        public bool StoreExist(Guid storeId)
        {
            using (_context)
            {
                var entity = _context.Stores.FirstOrDefault(x => x.Id == storeId);
                bool result = entity != null;
                return result;
            }
        }
    }
}

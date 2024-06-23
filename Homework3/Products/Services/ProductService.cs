using AutoMapper;
using Products.Absraction;
using Products.Models;
using Products.Models.DTO;

namespace Products.Services
{
    public class ProductService : IProductService
    {
        private IMapper _mapper;
        private ProductContext _context;

        public ProductService(IMapper mapper, ProductContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public Guid AddProduct(ProductDTO product)
        {
            using (_context)
            {
                var entity = _mapper.Map<Product>(product);
                _context.Products.Add(entity);
                _context.SaveChanges();
                return entity.Id;
            }
        }

        public Guid DeleteProductById(Guid id)
        {
            using (_context)
            {
                var productEntity = _context.Products.FirstOrDefault(x => x.Id == id);
                _context.Products.Remove(productEntity!);
                _context.SaveChanges();
                return productEntity.Id;
            }
        }

        public ProductDTO GetProductById(Guid id)
        {
            using (_context)
            {
                var entity = _context.Products.FirstOrDefault(x => x.Id == id);
                return _mapper.Map<ProductDTO>(entity);
            }
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        { 
            using (_context)
            {
                var products = _context.Products.Select(x => _mapper.Map<ProductDTO>(x)).ToList();
                return products;
            }
        }

        public bool ExistProduct(Guid id)
        {
            using (_context)
            {
                var entity = _context.Products.FirstOrDefault(x => x.Id == id);
                bool result = entity != null;
                return result;
            }
        }
    }
}

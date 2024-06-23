using Application.Abstraction;
using Application.Models;
using Application.Models.DTO;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Repo
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public ProductRepository(IMapper mapper, IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
        }
        public int AddGroup(GroupDto group)
        {
            using (var context = new ProductContext())
            {
                var entityGroup = context.ProductGroups.FirstOrDefault(x => x.Name.ToLower() == group.Name.ToLower());
                if (entityGroup == null)
                {
                    entityGroup = _mapper.Map<ProductGroup>(group);
                    context.ProductGroups.Add(entityGroup);
                    context.SaveChanges();
                    _memoryCache.Remove("groups");
                }
                return entityGroup.Id;
            }
        }

        public int AddProduct(ProductDto product)
        {
            using (var context = new ProductContext())
            {
                var entityProduct = context.Products.FirstOrDefault(x => x.Name.ToLower() == product.Name.ToLower());
                if (entityProduct == null)
                {
                    entityProduct = _mapper.Map<Product>(product);
                    context.Products.Add(entityProduct);
                    context.SaveChanges();
                    _memoryCache.Remove("products");
                }
                return entityProduct.Id;
            }
        }

        public IEnumerable<GroupDto> GetGroups()
        {
            if (_memoryCache.TryGetValue("groups", out List<GroupDto> groups))
            {
                return groups;
            }
            using (var context = new ProductContext())
            {
                var groupsList = context.ProductGroups.Select(x => _mapper.Map<GroupDto>(x)).ToList();
                _memoryCache.Set("groups", groupsList, TimeSpan.FromMinutes(30));
                return groupsList;
            }
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            if (_memoryCache.TryGetValue("products",out List<ProductDto> products))
            {
                return products;
            }
            using (var context = new ProductContext())
            {
                var productsList = context.Products.Select(x => _mapper.Map<ProductDto>(x)).ToList();
                _memoryCache.Set("products", productsList, TimeSpan.FromMinutes(30));
                return productsList;
            }
        }
    }
}

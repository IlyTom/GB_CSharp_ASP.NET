using Products.Models;
using Products.Models.DTO;

namespace Products.Absraction
{
    public interface IProductService
    {
        public Guid AddProduct(ProductDTO product);        
        public Guid DeleteProductById(Guid id);
        public ProductDTO GetProductById(Guid id);      
        
        public IEnumerable<ProductDTO> GetAllProducts();

        public bool ExistProduct(Guid id);

    }
}

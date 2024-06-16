using Application.Models.DTO;

namespace Application.Abstraction
{
    public interface IProductRepository
    {
        public int AddGroup(GroupDto group);

        public IEnumerable<GroupDto> GetGroups();

        public int AddProduct(ProductDto product);

        public IEnumerable<ProductDto> GetProducts();
    }
}

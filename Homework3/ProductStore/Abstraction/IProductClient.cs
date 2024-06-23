namespace ProductStore.Abstraction
{
    public interface IProductClient
    {
        public Task<bool> Exist(Guid productId);
    }
}

namespace ProductStore.Abstraction
{
    public interface IStoreClient
    {
        public Task<bool> Exist(Guid storeId);
    }
}

using ProductStore.Abstraction;

namespace ProductStore.Models
{
    public class StoreClient : IStoreClient
    {
        readonly HttpClient client = new HttpClient();

        public async Task<bool> Exist(Guid storeId)
        {
            using HttpResponseMessage response = await client.GetAsync($"https://localhost:5290/Store/StoreExist?storeId=${storeId}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            if (responseBody == "true")
            {
                return true;
            }
            if (responseBody == "false")
            {
                return false;
            }
            throw new Exception("Unknow response");
        }
    }

}

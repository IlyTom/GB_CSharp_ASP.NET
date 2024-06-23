using ProductStore.Abstraction;
using System.Reflection.Metadata.Ecma335;

namespace ProductStore.Models
{
    public class ProductClient : IProductClient
    {
        readonly HttpClient client = new HttpClient();
        public async Task<bool> Exist(Guid productId)
        {
            using HttpResponseMessage response = await client.GetAsync($"https://localhost:5177/controller/ExistProduct?productId=${productId}");
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

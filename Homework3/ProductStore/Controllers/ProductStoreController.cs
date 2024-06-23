using Microsoft.AspNetCore.Mvc;
using ProductStore.Abstraction;
using ProductStore.Models;
using ProductStore.Models.DTO;

namespace ProductStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductStoreController : ControllerBase
    {
        private IProductStore _productStore;
        public ProductStoreController(IProductStore productStore)
        {
            _productStore = productStore;
        }
        [HttpPost(template:("addStoreItem"))]
        public async Task<ActionResult<Guid>> AddStoreItem([FromQuery] StoreItemDTO product) {

            var storeExistTask = new StoreClient().Exist(product.StoreId);
            var productExistTask = new ProductClient().Exist(product.ProductId);
            if (await storeExistTask && await productExistTask)
            {
                _productStore.AddStoreItem(product);
                return Ok(product.ItemId);
            }
            else
            {
                return StatusCode(404);
            }
        }

        [HttpGet(template:("GetStoreItems"))]
        public ActionResult<IEnumerable<StoreItemDTO>> GetStoreItems()
        {
           return Ok(_productStore.GetStoreItems());
        }

        [HttpGet(template: ("GetStoreItemsById"))]
        public ActionResult<IEnumerable<StoreItemDTO>> GetStoreItemsById(Guid storeId)
        {
            return Ok(_productStore.GetStoreItems(storeId));
        }

        [HttpPost(template:("RemoveStoreItemQuantity"))]
        public ActionResult RemoveStoreItemQuantity(Guid itemId, decimal quantity)
        {
            _productStore.RemoveStoreItemQuantity(itemId, quantity);
            return Ok();
        }

        [HttpPost(template:("UpdateStoreItemQuantity"))]
        public ActionResult UpdateStoreItemQuantity(Guid itemId, decimal quantity)
        {
            _productStore.UpdateStoreItemQuantity(itemId, quantity);
            return Ok();
        }







    }
}

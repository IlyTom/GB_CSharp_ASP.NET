using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Abstraction;
using Store.Models.DTO;

namespace Store.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        private IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpPost(template: "AddStore")]
        public IActionResult AddStore([FromQuery] StoreDTO store)
        {
            var _store = _storeService.AddStore(store);
            return Ok(_store);
        }

        [HttpPost(template: "DeleteStore")]
        public IActionResult DeleteStore(Guid storeId)
        {
            var store = _storeService.DeleteStore(storeId);
            return Ok(store);
        }

        [HttpGet(template: "GetStoreById")]
        public IActionResult GetProduct(Guid storeId)
        {
            var store = _storeService.GetStoreById(storeId);
            return Ok(store);
        }

        [HttpGet(template: "GetAllStores")]
        public IActionResult GetAllStores()
        {
            var stores = _storeService.GetAllStores();
            return Ok(stores);
        }

        [HttpGet(template: "StoreExist")]
        public IActionResult StoreExist(Guid storeId)
        {
            return Ok(_storeService.StoreExist(storeId));
        }

    }
}

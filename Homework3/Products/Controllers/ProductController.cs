using Microsoft.AspNetCore.Mvc;
using Products.Absraction;
using Products.Models;
using Products.Models.DTO;

namespace Products.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService) { 
            _productService = productService;
        }

        [HttpPost(template:"AddProduct")]
        public IActionResult AddProduct([FromQuery]ProductDTO product) { 
            var item = _productService.AddProduct(product);
            return Ok(item);
        }

        [HttpPost(template:"DeleteProduct")]
        public IActionResult DeleteProduct(Guid productId)
        {
            var product = _productService.DeleteProductById(productId);
            return Ok(product);
        }

        [HttpGet(template:"GetProductById")]
        public IActionResult GetProduct(Guid productId)
        {
            var product = _productService.GetProductById(productId);
            return Ok(product);
        }

        [HttpGet(template:"GetAllProducts")]
        public IActionResult GetAllProducts() { 
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet(template: "ExistProduct")]
        public IActionResult ExistProduct(Guid productId)
        {
            return Ok(_productService.ExistProduct(productId));
        }
    }
}

using Application.Abstraction;
using Application.Models;
using Application.Models.DTO;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using ZstdSharp.Unsafe;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost(template: "addgroup")]
        public ActionResult AddGroup([FromBody] GroupDto groupDto)
        {
            var result = _productRepository.AddGroup(groupDto);
            return Ok(result);
        }

        [HttpGet(template: "getgroups")]
        public ActionResult<IEnumerable<ProductGroupModel>> GetGroups()
        {
            var groups = _productRepository.GetGroups();
            return Ok(groups);
        }


        [HttpPost(template: "addproduct")]
        public ActionResult AddProduct([FromBody] ProductDto productDto)
        {
            var result = _productRepository.AddProduct(productDto);
            return Ok(result);
        }


        [HttpGet(template: "getproducts")]
        public ActionResult<IEnumerable<ProductModel>> GetProducts()
        {
            var products = _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("export_prod_csv")]
        public IActionResult ExportCSV()
        {
            var products = _productRepository.GetProducts();

            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecord(products);
                writer.Flush();
                memoryStream.Position = 0;

                return File(memoryStream, "text/csv", "products.csv");
            }            
        }

        [HttpGet("cache_statistics_csv")]
        public IActionResult GetCacheStatisticsCsv()
        {
            var cacheStatistics = _productRepository.GetCacheStatistics();

            var memoryStream = new MemoryStream();
            using (var writer = new StreamWriter(memoryStream))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecord(cacheStatistics);
                writer.Flush();
                memoryStream.Position = 0;

                return File(memoryStream, "text/csv", "cache_statistics.csv");
            }
        }
    }
}


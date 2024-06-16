using Application.Models;
using Microsoft.AspNetCore.Mvc;
using ZstdSharp.Unsafe;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {


        [HttpPost(template: "addgroup")]
        public ActionResult AddGroup(string name, string description)
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    if (ctx.ProductGroups.Any(x => x.Name.ToLower() == name.ToLower()))
                    {
                        return StatusCode(409);
                    }
                    else
                    {
                        ctx.ProductGroups.Add(new ProductGroup { Name = name, Description = description });
                        ctx.SaveChanges();
                    }
                }

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet(template: "getgroups")]
        public ActionResult<IEnumerable<ProductGroupModel>> GetGroups()
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    var list = ctx.ProductGroups.Select(x => new ProductGroupModel { Id = x.Id, Name = x.Name, Description = x.Description }).ToList();
                    return list;
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }


        [HttpPost(template: "addproduct")]
        public ActionResult AddProduct(string name, string description, int groupId, int price)
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    if (ctx.Products.Any(x => x.Name.ToLower() == name.ToLower()))
                    {
                        return StatusCode(409);
                    }
                    else
                    {
                        ctx.Products.Add(new Product { Name = name, Description = description, ProductGroupId = groupId, Price = price });
                        ctx.SaveChanges();
                    }
                }

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }


        [HttpGet(template: "getproducts")]
        public ActionResult<IEnumerable<ProductModel>> GetProducts()
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    var list = ctx.Products.Select(x => new ProductModel { Name = x.Name, Description = x.Description, GroupName = x.ProductGroup.Name, Price = x.Price }).ToList();
                    return list;
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost(template: "deletegroup")]
        public ActionResult DeleteGroup(int groupId)
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    var group = ctx.ProductGroups.FirstOrDefault(x => x.Id == groupId);
                    if (group == null)
                    {
                        return NotFound();
                    }

                    ctx.ProductGroups.Remove(group);
                    ctx.SaveChanges();
                }

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost(template: "deleteproduct")]
        public ActionResult DeleteProduct(string name)
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    var product = ctx.Products.FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
                    if (product == null)
                    {
                        return NotFound();
                    }

                    ctx.Products.Remove(product);
                    ctx.SaveChanges();
                }

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost(template: "setproductprice")]
        public ActionResult SetProductPrice(string productName, int price)
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    var product = ctx.Products.FirstOrDefault(x => x.Name.ToLower().Equals(productName.ToLower()));
                    if (product == null)
                    {
                        return NotFound();
                    }

                    product.Price = price;
                    ctx.SaveChanges();
                }

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}


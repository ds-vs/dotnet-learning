using Microsoft.AspNetCore.Mvc;
using WebApplication01.Models;

namespace WebApplication01.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController: ControllerBase
    {
        private static List<Product> products = new List<Product>(new[] {
            new Product() { Id = 1, Name = "Notebook", Price = 100000 },
            new Product() { Id = 2, Name = "Car", Price = 2000000 },
            new Product() { Id = 3, Name = "Apple", Price = 30 },
        });

        [HttpGet]
        public IEnumerable<Product> Get() => products;

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var product = products.SingleOrDefault(product => product.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            products.Remove(products.SingleOrDefault(product => product.Id == id)!);
            return Ok();
        }
    }
}
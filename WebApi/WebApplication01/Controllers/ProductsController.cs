using Microsoft.AspNetCore.Mvc;
using WebApplication01.Models;

namespace WebApplication01.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController: ControllerBase
    {
        private int _nextProductId => 
            products.Count() == 0 ? 1 : products.Max(p => p.Id) + 1;

        private static List<Product> products = new List<Product>(new[] {
            new Product() { Id = 1, Name = "Notebook", Price = 100000 },
            new Product() { Id = 2, Name = "Car", Price = 2000000 },
            new Product() { Id = 3, Name = "Apple", Price = 30 },
            new Product() { Id = 4, Name = "Book", Price = 1000 }
        });

        [HttpGet]
        public IEnumerable<Product> Get() => products;

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var product = products.SingleOrDefault(product => product.Id == id);

            if (product == null)
            {
                return NotFound(); // 404
            }
            return Ok(product); // 200
        }

        [HttpGet("getNextProductId")]
        public int GetNextProductId()
        {
            return _nextProductId;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            products.Remove(products.SingleOrDefault(product => product.Id == id)!);
            return Ok(); // 200
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400
            }
            product.Id = _nextProductId;
            products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPost("AddProduct")]
        public IActionResult PostBody([FromBody] Product product) => Post(product);

        [HttpPut]
        public IActionResult Put(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); //400

            var storedProduct = products.SingleOrDefault(p => p.Id == product.Id);

            if (storedProduct == null)
                return NotFound(); // 404

            storedProduct.Name = product.Name;
            storedProduct.Price = product.Price;

            return Ok(storedProduct);
        }
    }
}
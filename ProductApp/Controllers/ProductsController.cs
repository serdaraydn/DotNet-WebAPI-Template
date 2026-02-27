 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;
namespace ProductApp.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, ProductName = "Laptop" },
                new Product { Id = 2, ProductName = "Smartphone" },
                new Product { Id = 3, ProductName = "Tablet" }
            };
            _logger.LogInformation("Retrieved all products.");
            return Ok(products);
        }
    }
}

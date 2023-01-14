using Microsoft.AspNetCore.Mvc;
using ProductStore.WebAPI.Models;
using ProductStore.WebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductStore.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<List<ProductEntity>> Get()
        {
            return await _productService.GetProductsAsync();
        }

        // GET: api/<ProductController>
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<ProductEntity>> Get(string id)
        {
            var product = await _productService.GetProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Create(ProductEntity product)
        {
            await _productService.Create(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, ProductEntity product)
        {
            var _product = await _productService.GetProductAsync(id);
            if (_product == null)
            {
                return NotFound();
            }
            else
            {
                product.Id = _product.Id;
                await _productService.Update(id, product);
                return NoContent();
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var _product = await _productService.GetProductAsync(id);
            if (_product == null)
            {
                return NotFound();
            }
            else
            {
                await _productService.Delete(id);
                return NoContent();
            }
        }
    }
}

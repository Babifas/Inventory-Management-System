using Inventory_Management_System.Models;
using Inventory_Management_System.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products =await _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            try
            {
                var book = await _productService.GetProductById(productId);
                if (book==null)
                {
                    return NotFound($"Book not found with {productId}");
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public  IActionResult AddProduct(Product product)
        {
            try
            {
                 _productService.AddProduct(product);
                return Ok("product added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}"); 
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            try
            {
                var res = await _productService.UpdateProduct(product);
                if (res)
                {
                    return Ok("Book updated successfully");
                }
                return NotFound($"Book not found with {product.ProductId}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                var res = await _productService.DeleteProduct(productId);
                if (res)
                {
                    return Ok("Book deleted successfully");
                }
                return NotFound($"Book not found with {productId}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

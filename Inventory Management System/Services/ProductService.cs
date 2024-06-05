using Inventory_Management_System.Data;
using Inventory_Management_System.Models;
using Inventory_Management_System.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_System.Services
{
    public class ProductService:IProductService
    {
        private readonly InventoryContext _inventoryContext;
        public ProductService(InventoryContext inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products =await _inventoryContext.Products.ToListAsync();
            return products;
        }
        public async Task<Product> GetProductById(int productId)
        {
            var product=await _inventoryContext.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
            if (product == null)
            {
                return null;
            }
            return product;
        }
        public async void AddProduct(Product product)
        {
             _inventoryContext.Add(product);
            _inventoryContext.SaveChanges();
        }
        public async Task<bool> UpdateProduct(Product product)
        {
            var _product=await _inventoryContext.Products.FirstOrDefaultAsync(p=>p.ProductId==product.ProductId);
            if (_product == null)
            {
                return false;
            }
            _product.Name = product.Name;
            _product.Description = product.Description;
            _product.Price = product.Price;
            _product.Stock = product.Stock;
            await _inventoryContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteProduct(int productId)
        {
            var product=await _inventoryContext.Products.FirstOrDefaultAsync(p=>p.ProductId == productId);
            if (product == null)
            {
                return false;
            }
            _inventoryContext.Remove(product);
            _inventoryContext.SaveChanges();
            return true;
        }
    }
}

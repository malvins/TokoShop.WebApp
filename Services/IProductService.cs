using TokoShop.WebApp.Models.Products;

namespace TokoShop.WebApp.Services
{
    public interface IProductService
    {
        public Task<bool> AddProduct(Product product);
        public Task<IEnumerable<Product>> GetAllAsync();
    }
}

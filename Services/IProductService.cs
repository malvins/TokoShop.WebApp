using TokoShop.WebApp.Models;
using TokoShop.WebApp.Models.Products;

namespace TokoShop.WebApp.Services
{
    public interface IProductService
    {
        public Task<bool> AddProduct(Product product);
        public Task<bool> UpdateProduct(Product product);
        public Task<IEnumerable<Product>> GetAllAsync();
        public Task<Product?> GetByIdAsync(Guid productId);
        public Task<Pageable<Product>> PaginateAsync(int page = 0, int take = 10, Dictionary<string, string> sorts = null, string filterText = null);
    }
}

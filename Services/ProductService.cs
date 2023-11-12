using Microsoft.EntityFrameworkCore;
using SqliteWasmHelper;
using TokoShop.WebApp.Models;
using TokoShop.WebApp.Models.Products;

namespace TokoShop.WebApp.Services
{
    public class ProductService: IProductService
    {
        private readonly ISqliteWasmDbContextFactory<DataContext> _dbContextFactory;
        public ProductService( ISqliteWasmDbContextFactory<DataContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<bool> AddProduct(Product product)
        {
            using var ctx = await _dbContextFactory.CreateDbContextAsync();
            ctx.Products.Add(product);
            await ctx.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var list = new List<Product>();
            try
            {
                using var ctx = await _dbContextFactory.CreateDbContextAsync();
                list = await ctx.Products.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            return list;
        }
    }
}

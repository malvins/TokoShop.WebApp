using Microsoft.EntityFrameworkCore;
using TokoShop.WebApp.Models.Products;

namespace TokoShop.WebApp.Models
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt): base(opt) { }

        public DbSet<Product> Products { get; set; } = null!;
    }
}

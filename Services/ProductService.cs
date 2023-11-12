using Microsoft.EntityFrameworkCore;
using SqliteWasmHelper;
using System.Linq.Dynamic.Core;
using TokoShop.WebApp.Models;
using TokoShop.WebApp.Models.Products;

namespace TokoShop.WebApp.Services
{
    public class ProductService : IProductService
    {
        private readonly ISqliteWasmDbContextFactory<DataContext> _dbContextFactory;
        public ProductService(ISqliteWasmDbContextFactory<DataContext> dbContextFactory)
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
        public async Task<Pageable<Product>> PaginateAsync(int page = 0, int take = 10, Dictionary<string, string> sorts = null, string filterText = null)
        {
            var result = new Pageable<Product>();
            try
            {
                using var ctx = await _dbContextFactory.CreateDbContextAsync();
                var query = ctx.Products.Where(o => 1 == 1);
                if (!string.IsNullOrEmpty(filterText))
                {
                    query = query.Where(x => x.Name.Contains(filterText) || x.Description.Contains(filterText));
                }
                if (sorts?.Any() == true)
                {
                    foreach (var sort in sorts)
                    {
                        var sortVal = sort.Value.ToLowerInvariant();
                        if (!new[] { "desc", "asc" }.Contains(sortVal))
                        {
                            continue;
                        }
                        query = query.OrderBy($"{sort.Key} {sortVal}");
                    }
                }
                else
                {
                    query = query.OrderBy($"name asc");
                }
                var count = query.Count();
                var items = await query.Skip(page * take).Take(take).ToListAsync();
                result.Items = items;
                result.DataCount = count;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}

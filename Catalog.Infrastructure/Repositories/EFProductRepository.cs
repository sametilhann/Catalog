using Catalog.Application.Contracts;
using Catalog.Entities;
using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly EGMCatalogDbContext dbContext;
        public EFProductRepository(EGMCatalogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(Product entity)
        {
             await dbContext.Products.AddAsync(entity);
             await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await dbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);  
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<Product>> GetAll()
        {
           return await dbContext.Products.ToListAsync();
        }

        public Task<Product?> GetById(int id)
        {
            return dbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int id)
        {
            return await dbContext.Products.Where(p => p.CategoryId == id).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsWithCategory()
        {
            return await dbContext.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
        {
            return await dbContext.Products.Where(p => p.Name.Contains(name,StringComparison.OrdinalIgnoreCase)).ToListAsync();
        }

        public async Task Update(Product entity)
        {
            dbContext.Products.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}

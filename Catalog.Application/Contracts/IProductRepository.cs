using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> SearchByNameAsync(string name);

        Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId);

        Task<IEnumerable<Product>> GetProductsWithCategory();
    }
}

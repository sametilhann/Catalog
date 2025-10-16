using Catalog.Application.DataTransferObjects;
using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductsDisplayResponse>>GetProducts();
    }
}

using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Contracts
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}

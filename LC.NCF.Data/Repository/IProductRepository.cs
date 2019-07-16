using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LC.NCF.Data.Models;

namespace LC.NCF.Data.Repository
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(long id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CEMIG.MapadoSite.Data.Models;

namespace CEMIG.MapadoSite.Business.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(long id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetAlllAsync();
        Task AddAsync(Product product);
    }
}
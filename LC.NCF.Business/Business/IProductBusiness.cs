using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LC.NCF.Business.Contracts;
using LC.NCF.Data.Models;

namespace LC.NCF.Business.Business
{
    public interface IProductBusiness
    {
        Task<ProductResponse> GetAsync(long id);
        Task<ProductResponse> GetAllAsync();
        Task<ProductResponse> GetAlllAsync();
        Task AddAsync(ProductRequest productRequest);
    }
}
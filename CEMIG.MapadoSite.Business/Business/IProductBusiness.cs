using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CEMIG.MapadoSite.Business.Contracts;
using CEMIG.MapadoSite.Data.Models;

namespace CEMIG.MapadoSite.Business.Business
{
    public interface IProductBusiness
    {
        Task<ProductResponse> GetAsync(long id);
        Task<ProductResponse> GetAllAsync();
        Task<ProductResponse> GetAlllAsync();
        Task AddAsync(ProductRequest productRequest);
    }
}
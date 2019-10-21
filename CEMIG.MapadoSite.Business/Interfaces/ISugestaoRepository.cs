using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CEMIG.MapadoSite.Data.Models;

namespace CEMIG.MapadoSite.Business.Interfaces
{
    public interface ISugestaoRepository
    {
        void AddSugestao(Sugestao sugestao);
        IEnumerable<Sugestao> GetAllSugestoes();
        Task<IEnumerable<Sugestao>> GetAllSugestoesAsync();
    }
}
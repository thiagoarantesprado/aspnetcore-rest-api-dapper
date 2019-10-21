using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CEMIG.MapadoSite.Business.Contracts;
using CEMIG.MapadoSite.Data.Models;

namespace CEMIG.MapadoSite.Business.Business
{
    public interface ISugestaoBusiness
    {
        void AddSugestao(Sugestao sugestao);
        List<Sugestao> GetAllSugestoes();
    }
}
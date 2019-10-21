using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIG.MapadoSite.Business.Contracts;
using CEMIG.MapadoSite.Business.Interfaces;
using CEMIG.MapadoSite.Data.Models;

namespace CEMIG.MapadoSite.Business.Business
{
    public class SugestaoBusiness : ISugestaoBusiness
    {
        private readonly ISugestaoRepository _sugestaoRepository;

        public SugestaoBusiness(ISugestaoRepository sugestaoRepository)
        {
            _sugestaoRepository = sugestaoRepository;
        }

        public void AddSugestao(Sugestao sugestao)
        {
            _sugestaoRepository.AddSugestao(sugestao);
        }

        public List<Sugestao> GetAllSugestoes()
        {
            List<Sugestao> sugestoes = _sugestaoRepository.GetAllSugestoes().ToList();

            return sugestoes;
        }
    }
}
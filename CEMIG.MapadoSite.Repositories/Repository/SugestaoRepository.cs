using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CEMIG.MapadoSite.Data.Models;
using Dapper;
using CEMIG.MapadoSite.Business.Interfaces;

namespace CEMIG.MapadoSite.Repositories.Repository
{
    public class SugestaoRepository : ISugestaoRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public SugestaoRepository()
        {
            // TODO: It will be refactored...
            _connectionString = "Data Source=cemigsqlsrv.database.windows.net;Initial Catalog=CEMIG_SITE;User ID=cemig;Password=2019@bhs;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public async Task<IEnumerable<Sugestao>> GetAllSugestoesAsync()
        {
            //TODO: Paging...
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT *
                                FROM [dbo].[Sugestoes]";

                var sugestoes = await dbConnection.QueryAsync<Sugestao>(query);

                return sugestoes;
            }
        }

        public IEnumerable<Sugestao> GetAllSugestoes()
        {
            //TODO: Paging...
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT *
                                FROM [dbo].[Sugestoes] order by id desc";

                var sugestoes = dbConnection.Query<Sugestao>(query);

                return sugestoes;
            }
        }

        public void AddSugestao(Sugestao sugestao)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"INSERT INTO [dbo].[Sugestoes] (
                                [Observacao],
                                [Usuario]) VALUES (
                                @Observacao,
                                @Usuario)";

                dbConnection.Execute(query, sugestao);
            }
        }
    }
}

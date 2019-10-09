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
    public class MenuRepository : IMenuRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public MenuRepository()
        {
            // TODO: It will be refactored...
            _connectionString = "Data Source=cemigsqlsrv.database.windows.net;Initial Catalog=CEMIG_SITE;User ID=cemig;Password=2019@bhs;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public async Task<IEnumerable<Menu>> GetAllMenuAsync()
        {
            //TODO: Paging...
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT *
                                FROM [dbo].[Menu]";

                var menu = await dbConnection.QueryAsync<Menu>(query);

                return menu;
            }
        }

        public IEnumerable<Menu> GetAllMenus()
        {
            //TODO: Paging...
            using (IDbConnection dbConnection = _connection)
            {
                string sqlProcedure = @"PROC_MENU_HIERARQUIA_LISTAR";

                var menu = dbConnection.Query<Menu>(sqlProcedure, commandType: CommandType.StoredProcedure);

                return menu;
            }
        }

        public Menu GetMenu(int id)
        {
            //TODO: Paging...
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT *
                                FROM [dbo].[Menu]
                                WHERE Id=@Id";

                var menu = dbConnection.Query<Menu>(query, new { @Id = id });

                return menu.FirstOrDefault();
            }
        }

        public void AddPaginaAusente(PaginaAusente paginaAusente)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"INSERT INTO [dbo].[PaginasAusente] (
                                [Link],
                                [Observacao],
                                [Usuario]) VALUES (
                                @Link,
                                @Observacao,
                                @Usuario)";

                dbConnection.Execute(query, paginaAusente);
            }
        }

        public List<PaginaAusente> GetAllPaginasAusente()
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT *
                                FROM [dbo].[PaginasAusente]
                                ORDER BY ID DESC";

                var menu = dbConnection.Query<PaginaAusente>(query);

                return menu.ToList();
            }
        }

        public void AddMenuAvaliacao(MenuAvaliacao menuAvaliacao)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"INSERT INTO [dbo].[MenuAvaliacao] (
                                [IdMenu],
                                [InfoCorreta],
                                [ePaginaRegulatoria],
                                [PaginaSeraMantida],
                                [Justificativa],
                                [Usuario]) VALUES (
                                @IdMenu,
                                @InfoCorreta,
                                @ePaginaRegulatoria,
                                @PaginaSeraMantida,
                                @Justificativa,
                                @Usuario)";

                dbConnection.Execute(query, menuAvaliacao);
            }
        }

        public List<MenuAvaliacao> GetMenuAvaliacoes(int idMenu)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT *
                                FROM [dbo].[MenuAvaliacao]
                                WHERE IdMenu=@idMenu order by id desc";

                var menu = dbConnection.Query<MenuAvaliacao>(query, new { @idMenu = idMenu });

                return menu.ToList();
            }
        }

        public List<MenuAnaliseAvaliacao> GetMenuQuePossuemAvaliacoes()
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT 
	                                me.Id, me.Nome, me.Link, me.cor, me.QtdViewPage, me.QtdUnViewPage,
                                    me.QtdEnterAcess,me.MediumTimeAccess,me.RejectionTax,me.ExitTax,
	                                COUNT(ma.IdMenu) as quantAvaliacoes
                                FROM 
	                                [dbo].[MenuAvaliacao] ma
                                INNER JOIN 
	                                [dbo].[Menu] me ON ma.IdMenu = me.Id
                                WHERE me.link like '%.aspx%'
                                GROUP BY me.Id, me.Nome, me.Link, me.cor, me.QtdViewPage, me.QtdUnViewPage,
                                me.QtdEnterAcess,me.MediumTimeAccess,me.RejectionTax,me.ExitTax";

                var menu = dbConnection.Query<MenuAnaliseAvaliacao>(query);

                return menu.ToList();
            }
        }

        public List<MenuAnaliseAvaliacao> GetMenuQueNaoPossuemAvaliacoes()
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT 
	                                me.Id, me.Nome, me.Link, me.cor, me.QtdViewPage, me.QtdUnViewPage,
                                    me.QtdEnterAcess,me.MediumTimeAccess,me.RejectionTax,me.ExitTax,
	                                COUNT(ma.IdMenu) as quantAvaliacoes
                                FROM 
	                                [dbo].[MenuAvaliacao] ma
                                RIGHT OUTER JOIN 
	                                [dbo].[Menu] me ON ma.IdMenu = me.Id
                                WHERE me.link like '%.aspx%'
                                GROUP BY me.Id, me.Nome, me.Link, me.cor, me.QtdViewPage, me.QtdUnViewPage,
                                me.QtdEnterAcess,me.MediumTimeAccess,me.RejectionTax,me.ExitTax
                                HAVING COUNT(ma.IdMenu) = 0
                                ORDER BY me.QtdViewPage DESC";

                var menu = dbConnection.Query<MenuAnaliseAvaliacao>(query);

                return menu.ToList();
            }
        }

        public List<MenuAvaliacao> GetAllMenuAvaliacao()
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT *
                                FROM [dbo].[MenuAvaliacao]";

                var menu = dbConnection.Query<MenuAvaliacao>(query);

                return menu.ToList();
            }
        }

        public IEnumerable<Menu> GetAllMenu()
        {
            //TODO: Paging...
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT *
                                FROM [dbo].[Menu]";

                var menu = dbConnection.Query<Menu>(query);

                return menu;
            }
        }
    }
}

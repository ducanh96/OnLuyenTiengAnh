using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using PracticeEnglish.Models;
using Dapper;
using PracticeEnglish.Data.Interface;
using PracticeEnglish;
using PracticeEnglish.Contracts.Response;

namespace PracticeEnglish.Data.Implement
{
    public class DocRepository : IDocRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public DocRepository()
        {
            // TODO: It will be refactored...
            _connectionString = ConfigSetting._connectionString;
        }

        public async Task<IEnumerable<Doc>> LayDSDoanVan(int idChuDe)
        {
             using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT ID, DoanVan, IDChuDe FROM Doc WHERE IDChuDe = @IDChuDe";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@IDChuDe", idChuDe, DbType.Int16);
                var doc = await dbConnection.QueryAsync<Doc>(query, param: parameters);
                return doc;
            }
        }

        public async Task<string> GetParagraph(int idDeThi)
        {
              using (IDbConnection dbConnection = _connection)
            {
                string query = @"select [DoanVan] from Doc where [Id] = (select  Top 1 [IDDoc] from CauHoi where [IDDeThi] = @IdDeThi)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@IdDeThi", idDeThi, DbType.Int16);
                var doanVan = await dbConnection.QueryFirstAsync<string>(query, param: parameters);
                return doanVan;
            }
        }
    }
}

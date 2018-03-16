using Dapper;
using PracticeEnglish.Data.Interface;
using PracticeEnglish.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeEnglish.Data.Implement
{
    public class ChuDeRepository : IChuDeRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public ChuDeRepository()
        {
            // TODO: It will be refactored...
            _connectionString = "Server=DESKTOP-ET1GGIC\\SQLEXPRESS;Database=B1Online;Trusted_Connection=True;MultipleActiveResultSets=true";

        }
        public async Task<IEnumerable<ChuDe>> Gets()
        {
            using (IDbConnection dbConnection = _connection)
            {
               string query = @"SELECT [ID] ,[TenChuDe]
                               FROM [dbo].[ChuDe]";

               var chuDe = await dbConnection.QueryAsync<ChuDe>(query);
               return chuDe.ToArray();
            }
         
        }
    }
}

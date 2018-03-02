using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using PracticeEnglish.Models;
using Dapper;
using PracticeEnglish.Data.Interface;

namespace PracticeEnglish.Data.Implement
{
    public class DeThiRepository : IDeThiRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public DeThiRepository()
        {
            // TODO: It will be refactored...
            _connectionString = "Server=DESKTOP-ET1GGIC\\SQLEXPRESS;Database=B1Online;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        public async Task<IEnumerable<DeThi>> GetListDeThi_ChuDe(int id)
        {

            using (IDbConnection dbConnection = _connection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@IdTopic", id ,DbType.Int16);
                var listDeThi = await dbConnection.QueryAsync<DeThi>(Constants.DeThi_GetListByTopic, param: parameters,
         commandType: CommandType.StoredProcedure);

                return listDeThi;

            }
        }
    }
}
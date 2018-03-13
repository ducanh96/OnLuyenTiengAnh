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
    public class NgheRepository : INgheRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public NgheRepository()
        {
            // TODO: It will be refactored...
            _connectionString = ConfigSetting._connectionString;
        }





        public async Task<IEnumerable<Nghe>> LayDSFileNghe(int idChuDe)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT ID, FileNghe, IDChuDe FROM Nghe WHERE IDChuDe = @IDChuDe";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@IDChuDe", idChuDe, DbType.Int16);
                var nghe = await dbConnection.QueryAsync<Nghe>(query, param: parameters);
                return nghe;
            }


        }
    }
}

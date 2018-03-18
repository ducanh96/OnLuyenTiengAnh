
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using PracticeEnglish.Models;
using Dapper;
using PracticeEnglish.Data.Interface;
using PracticeEnglish;

using PracticeEnglish.Contracts.Request;


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


        public async Task<IEnumerable<Nghe>> LayDSFileNghe(GetListFileNgheRequest r)
        {
            using (IDbConnection dbConnection = _connection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@idChuDe", r.idTopic ,DbType.Int32);
                var listFileNghe = await dbConnection.QueryAsync<Nghe>(Constants.Nghe_GetListByTopic , param: parameters, commandType: CommandType.StoredProcedure);
                return listFileNghe;
            }
        }

        public async Task<int> ThemFileNghe(ThemFileNgheRequest r)
        {
           using (IDbConnection dbConnection = _connection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FileNghe", r.FileNghe ,DbType.String);
                parameters.Add("@IDChuDe", r.IDChuDe ,DbType.String);
                var listCauHoi = await dbConnection.ExecuteAsync(Constants.Nghe_Them , param: parameters, commandType: CommandType.StoredProcedure);
                return listCauHoi;
            }
        }

        public async Task<int> SuaFileNghe(SuaFileNgheRequest r)
        {
            using (IDbConnection dbConnection = _connection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FileNghe", r.FileNghe ,DbType.String);
                parameters.Add("@IDChuDe", r.IDChuDe ,DbType.String);
                parameters.Add("@ID", r.ID ,DbType.String);
                var listCauHoi = await dbConnection.ExecuteAsync(Constants.Nghe_Sua , param: parameters, commandType: CommandType.StoredProcedure);
                return listCauHoi;
            }
        }

        public async Task<bool> XoaFileNghe(XoaFileNgheRequest r)
        {
            using (IDbConnection dbConnection = _connection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", r.ID ,DbType.Int32);
                int listCauHoi = await dbConnection.ExecuteAsync(Constants.Nghe_Xoa , param: parameters, commandType: CommandType.StoredProcedure);
                return  (listCauHoi>0 ? true: false )  ;
            }
        }

        public async Task<string> GetMusic(int idDeThi)
        {
             using (IDbConnection dbConnection = _connection)
            {
                string query = @"select [FileNghe] from Nghe where [Id] = (select  Top 1 [IDNghe] from CauHoi where [IDDeThi] = @IdDeThi)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@IdDeThi", idDeThi, DbType.Int16);
                var doanNghe = await dbConnection.QueryFirstAsync<string>(query, param: parameters);
                return doanNghe;
            }
        }
    }
}







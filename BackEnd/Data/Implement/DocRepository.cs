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
    public class DocRepository : IDocRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public DocRepository()
        {
            // TODO: It will be refactored...
            _connectionString = ConfigSetting._connectionString;
        }    

        public async Task<IEnumerable<Doc>> LayDSDoanVan(GetListDoanVanRequest r)
        {
            using (IDbConnection dbConnection = _connection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@idChuDe", r.idTopic ,DbType.Int32);
                var listDoanVan = await dbConnection.QueryAsync<Doc>(Constants.Doc_GetListByTopic , param: parameters, commandType: CommandType.StoredProcedure);
                return listDoanVan;
            }
        }

        public async Task<int> ThemDoanVan(ThemDoanVanRequest r)
        {
            using (IDbConnection dbConnection = _connection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DoanVan", r.DoanVan ,DbType.String);
                parameters.Add("@IDChuDe", r.IDChuDe ,DbType.String);
                var listCauHoi = await dbConnection.ExecuteAsync(Constants.Doc_Them , param: parameters, commandType: CommandType.StoredProcedure);
                return listCauHoi;
            }
        }

        public async Task<int> SuaDoanVan(SuaDoanVanRequest r)
        {
            using (IDbConnection dbConnection = _connection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DoanVan", r.DoanVan ,DbType.String);
                parameters.Add("@IDChuDe", r.IDChuDe ,DbType.String);
                parameters.Add("@ID", r.ID ,DbType.String);
                var listCauHoi = await dbConnection.ExecuteAsync(Constants.Doc_Sua , param: parameters, commandType: CommandType.StoredProcedure);
                return listCauHoi;
            }
        }

        public async Task<bool> XoaDoanVan(XoaDoanVanRequest r)
        {
            using (IDbConnection dbConnection = _connection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", r.ID ,DbType.Int32);
                int listCauHoi = await dbConnection.ExecuteAsync(Constants.CauHoi_Xoa , param: parameters, commandType: CommandType.StoredProcedure);
                return  (listCauHoi>0 ? true: false )  ;
            }
        }
    }
}
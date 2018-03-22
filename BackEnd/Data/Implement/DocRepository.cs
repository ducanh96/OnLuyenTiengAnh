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

        public async Task<AddResponse> ThemDoanVan(ThemDoanVanRequest r)
        {
            try
            {
                using (IDbConnection dbConnection = _connection)
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@DoanVan", r.DoanVan, DbType.String);
                    parameters.Add("@IDChuDe", r.IDChuDe, DbType.String);
                    await dbConnection.ExecuteAsync(Constants.Doc_Them, param: parameters, commandType: CommandType.StoredProcedure);
                    return new AddResponse
                    {
                        Code = 1
                    };
                }
            }
            catch (Exception ex)
            {
                return new AddResponse
                {
                    Code = 0,
                    Message = ex.Message
                };
            }

        }

        public async Task<AddResponse> SuaDoanVan(SuaDoanVanRequest r)
        {
            try
            {
                using (IDbConnection dbConnection = _connection)
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@DoanVan", r.DoanVan, DbType.String);
                    parameters.Add("@IDChuDe", r.IDChuDe, DbType.String);
                    parameters.Add("@ID", r.ID, DbType.String);
                    var listCauHoi = await dbConnection.ExecuteAsync(Constants.Doc_Sua, param: parameters, commandType: CommandType.StoredProcedure);
                   string query = @"SELECT  top 1 ID from Doc ";
                    return new AddResponse
                    {
                        Code =  await dbConnection.QueryFirstAsync<int>(query, param: parameters)
                    };
                }
            }
            catch (Exception ex)
            {
                return new AddResponse
                {
                    Code = 0,
                    Message = ex.Message
                };
            }

        }
    
        public async Task<bool> XoaDoanVan(XoaDoanVanRequest r)
        {
            using (IDbConnection dbConnection = _connection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", r.ID ,DbType.Int32);
                int listCauHoi = await dbConnection.ExecuteAsync(Constants.Doc_Xoa , param: parameters, commandType: CommandType.StoredProcedure);
                return  (listCauHoi>0 ? true: false )  ;
            }
        }
    }
}

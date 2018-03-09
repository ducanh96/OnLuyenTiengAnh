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
    public class DeThiRepository : IDeThiRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public DeThiRepository()
        {
            // TODO: It will be refactored...
            _connectionString = ConfigSetting._connectionString;
        }

        public async Task<IEnumerable<DeThi>> GetListDeThi_ChuDe(int id)
        {

            using (IDbConnection dbConnection = _connection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@IdTopic", id, DbType.Int16);
                var listDeThi = await dbConnection.QueryAsync<DeThi>(Constants.DeThi_GetListByTopic, param: parameters,
         commandType: CommandType.StoredProcedure);

                return listDeThi;

            }
        }


        public async Task<DeThiAddResponse> Add(DeThi deThi)
        {
            try
            {
                using (IDbConnection dbConnection = _connection)
                {
                    string query = @"INSERT INTO [dbo].[DeThi]([MaDe], [IDChuDe]) VALUES (
                               
                                @MaDe,
                                @IDChuDe)";
                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@MaDe", deThi.MaDe, DbType.String);
                    parameters.Add("@IDChuDe", deThi.IDChuDe, DbType.Int16);
                    await dbConnection.ExecuteAsync(query, param: parameters);
                    return new DeThiAddResponse
                    {
                        Code = 1
                    };
                }
            }
            catch (Exception ex)
            {
                return new DeThiAddResponse
                {
                    Code = 0,
                    Message = ex.Message
                };
            }


        }


        public async Task<DeThiAddResponse> UpdateCauHoi_DeThi(int idCauHoi, int idDeThi)
        {
            try
            {
                using (IDbConnection dbConnection = _connection)
                {
                    string query = @"Update CauHoi
                                    set IDDeThi = @IDDeThi
                                    Where ID = @IdCauHoi";
                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@IDDeThi", idDeThi, DbType.Int16);
                    parameters.Add("@IDCauHoi", idCauHoi, DbType.Int16);
                    await dbConnection.ExecuteAsync(query, param: parameters);
                    return new DeThiAddResponse
                    {
                        Code = 1
                    };
                }
            }
            catch (Exception ex)
            {
                return new DeThiAddResponse
                {
                    Code = 0,
                    Message = ex.Message
                };
            }


        }



        public async Task<int> GetLastId(string table)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT IDENT_CURRENT(@tenBang)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@tenBang", table, DbType.String);

                var listDeThi = await dbConnection.QueryFirstAsync<int>(query, param: parameters);

                return listDeThi;

            }
        }
    }
}
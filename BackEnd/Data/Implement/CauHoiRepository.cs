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
    public class CauHoiRepository : ICauHoiRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public CauHoiRepository()
        {
            // TODO: It will be refactored...
            _connectionString = ConfigSetting._connectionString;
        }

        // public async Task<IEnumerable<DeThi>> GetListDeThi_ChuDe(GetListCauHoiRequest r)
        // {

        //     using (IDbConnection dbConnection = _connection)
        //     {
        //         DynamicParameters parameters = new DynamicParameters();
        //         parameters.Add("@IdTopic", r.idTopic ,DbType.Int16);
        //         var listDeThi = await dbConnection.QueryAsync<DeThi>(Constants.DeThi_GetListByTopic, param: parameters,
        //  commandType: CommandType.StoredProcedure);

        //         return listDeThi;

        //     }
        // }

        public async Task<IEnumerable<CauHoi>> GetListCauHoi(GetListCauHoiRequest r)
        {
            using (IDbConnection dbConnection = _connection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@idChuDe", r.idTopic ,DbType.Int32);
                var listCauHoi = await dbConnection.QueryAsync<CauHoi>(Constants.CauHoi_GetListByTopic , param: parameters, commandType: CommandType.StoredProcedure);
                return listCauHoi;
            }
        }

        public async Task<int> ThemCauHoi(ThemCauHoiRequest r)
        {
            using (IDbConnection dbConnection = _connection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PhuongAnA", r.PhuongAnA ,DbType.String);
                parameters.Add("@PhuongAnB", r.PhuongAnB ,DbType.String);
                parameters.Add("@PhuongAnC", r.PhuongAnC ,DbType.String);
                parameters.Add("@PhuongAnD", r.PhuongAnD ,DbType.String);
                parameters.Add("@TieuDe", r.TieuDe ,DbType.String);
                parameters.Add("@DapAn", r.DapAn ,DbType.String);
                parameters.Add("@IDNghe ", r.IDNghe ,DbType.Int32);
                parameters.Add("@IDDoc", r.IDDoc ,DbType.Int32);
                parameters.Add("@IDDethi", r.IDDethi ,DbType.Int32);
                parameters.Add("@IDChuDe", r.IDChuDe ,DbType.Int32);
                var listCauHoi = await dbConnection.ExecuteAsync(Constants.CauHoi_Them , param: parameters, commandType: CommandType.StoredProcedure);
                return listCauHoi;
            }
        }

        public async Task<int> SuaCauHoi(SuaCauHoiRequest r)
        {
           using (IDbConnection dbConnection = _connection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", r.ID ,DbType.Int32);
                parameters.Add("@PhuongAnA", r.PhuongAnA ,DbType.String);
                parameters.Add("@PhuongAnB", r.PhuongAnB ,DbType.String);
                parameters.Add("@PhuongAnC", r.PhuongAnC ,DbType.String);
                parameters.Add("@PhuongAnD", r.PhuongAnD ,DbType.String);
                parameters.Add("@TieuDe", r.TieuDe ,DbType.String);
                parameters.Add("@DapAn", r.DapAn ,DbType.String);
                parameters.Add("@IDNghe ", r.IDNghe ,DbType.Int32);
                parameters.Add("@IDDoc", r.IDDoc ,DbType.Int32);
                parameters.Add("@IDDethi", r.IDDethi ,DbType.Int32);
                parameters.Add("@IDChuDe", r.IDChuDe ,DbType.Int32);
                var listCauHoi = await dbConnection.ExecuteAsync(Constants.CauHoi_Sua , param: parameters, commandType: CommandType.StoredProcedure);
                return listCauHoi;
            }
        }

        public async Task<bool> XoaCauHoi(XoaCauHoiRequest r)
        {
           using (IDbConnection dbConnection = _connection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", r.ID ,DbType.Int32);
                int listCauHoi = await dbConnection.ExecuteAsync(Constants.CauHoi_Xoa , param: parameters, commandType: CommandType.StoredProcedure);
                return  (listCauHoi>0 ? true: false )  ;
            }
        }

        public async Task<bool> XoaCauHoiByIdDoc(XoaCauHoiByIDDocRequest r)
        {
            using (IDbConnection dbConnection = _connection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@IDDoc", r.IDDoc ,DbType.Int32);
                int listCauHoi = await dbConnection.ExecuteAsync(Constants.CauHoi_XoaByIdDoc , param: parameters, commandType: CommandType.StoredProcedure);
                return  (listCauHoi>0 ? true: false )  ;
            }
        }

        public async Task<bool> XoaCauHoiByIdNghe(XoaCauHoiByIDNgheRequest r)
        {
            using (IDbConnection dbConnection = _connection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@IDNghe", r.IDNghe ,DbType.Int32);
                int listCauHoi = await dbConnection.ExecuteAsync(Constants.CauHoi_XoaByIdNghe , param: parameters, commandType: CommandType.StoredProcedure);
                return  (listCauHoi>0 ? true: false )  ;
            }
        }

        public async Task<IEnumerable<CauHoi>> GetListCauHoi_KhongThuocDeThi(int idTopic)
        {
            using (IDbConnection dbConnection = _connection)
            {
               string query = @"SELECT [ID]
                                ,[TieuDe]
                                ,[PhuongAnA]
                                ,[PhuongAnB]
                                ,[PhuongAnC]
                                ,[PhuongAnD]
                                ,[DapAn]
                                ,[IDNghe]
                                ,[IDDoc]
                                ,[IDDeThi]
                                ,[IDChuDe] FROM [dbo].[CauHoi] WHERE [IDChuDe] = @Id And [IDDeThi] is NULL";

               var listCauHoi = await dbConnection.QueryAsync<CauHoi>(query,new{ @Id = idTopic});
               return listCauHoi;
            }
        }

        public async Task<IEnumerable<CauHoi>> GetListCauHoi_IDNghe(int idNghe)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT [ID]
                                ,[TieuDe]
                                ,[PhuongAnA]
                                ,[PhuongAnB]
                                ,[PhuongAnC]
                                ,[PhuongAnD]
                                ,[DapAn]
                                ,[IDNghe]
                                ,[IDDoc]
                                ,[IDDeThi]
                                ,[IDChuDe] FROM [dbo].[CauHoi] WHERE [IDNghe] = @IdNghe";

                var listCauHoi = await dbConnection.QueryAsync<CauHoi>(query, new { @IdNghe = idNghe });
                return listCauHoi;
            }
        }
    }
}
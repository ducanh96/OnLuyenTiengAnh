using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PracticeEnglish.Contracts.Response;
using PracticeEnglish.Models;

namespace PracticeEnglish.Data.Interface
{
    public interface IDeThiRepository
    {
        Task<IEnumerable<DeThi>> GetListDeThi_ChuDe(int id);
        Task<DeThiAddResponse> Add(DeThi deThi);
        Task<int> GetLastId(string table);
        Task<DeThiAddResponse> UpdateCauHoi_DeThi(int idCauHoi, int idDeThi);
    }
}
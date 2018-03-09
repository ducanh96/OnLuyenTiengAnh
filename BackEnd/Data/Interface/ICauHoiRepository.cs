using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PracticeEnglish.Contracts.Request;
using PracticeEnglish.Models;

namespace PracticeEnglish.Data.Interface
{
    public interface ICauHoiRepository
    {
        Task<IEnumerable<CauHoi>> GetListCauHoi(GetListCauHoiRequest r);
        // Task<int> ThemCauHoi(ThemCauHoiRequest r);
        // Task<int> SuaCauHoi(SuaCauHoiRequest r);
        // Task<bool> XoaCauHoi(XoaCauHoiRequest r);
        // Task<bool> XoaCauHoiByIdDoc(XoaCauHoiByIDDocRequest r);
        // Task<bool> XoaCauHoiByIdNghe(XoaCauHoiByIDNgheRequest r);
        Task<IEnumerable<CauHoi>> GetListCauHoi_KhongThuocDeThi(int idTopic);
    }
}
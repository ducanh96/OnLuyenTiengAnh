using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PracticeEnglish.Models;

namespace PracticeEnglish.Data.Interface
{
    public interface ICauHoiRepository
    {
        Task<IEnumerable<CauHoi>> GetListCauHoi(int idChuDe);
        Task<int> ThemCauHoi(CauHoi cauhoi);
        Task<int> SuaCauHoi(CauHoi cauhoi);
        Task<bool> XoaCauHoi(int id);
        Task<bool> XoaCauHoiByIdDoc(int idDoc);
        Task<bool> XoaCauHoiByIdNghe(int idNghe);
    }
}
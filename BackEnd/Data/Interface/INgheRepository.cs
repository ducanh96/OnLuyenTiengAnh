using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PracticeEnglish.Models;

namespace PracticeEnglish.Data.Interface
{
    public interface INgheRepository
    {
        Task<IEnumerable<Nghe>> LayDSFileNghe(int idChuDe);
        Task<int> ThemFileNghe(Nghe nghe);
        Task<int> SuaFileNghe(Nghe nghe);
        Task<bool> XoaFileNghe(int id);
    }
}
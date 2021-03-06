using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PracticeEnglish.Models;
using PracticeEnglish.Contracts.Request;
using PracticeEnglish.Contracts.Response;

namespace PracticeEnglish.Data.Interface
{
    public interface INgheRepository
    {
        Task<IEnumerable<Nghe>> LayDSFileNghe(GetListFileNgheRequest r);
        Task<AddResponse> ThemFileNghe(ThemFileNgheRequest r);
        Task<AddResponse> SuaFileNghe(SuaFileNgheRequest r);
        Task<bool> XoaFileNghe(XoaFileNgheRequest r);
       // Task<IEnumerable<Nghe>> LayDSFileNghe(int idChuDe);
        //Task<int> ThemFileNghe(Nghe nghe);
        //Task<int> SuaFileNghe(Nghe nghe);
        //Task<bool> XoaFileNghe(int id);
        //Task<IEnumerable<Nghe>> GetListNghe_KhongThuocDeThi(int idChuDe);
        Task<string> GetMusic(int idDeThi);

    }
}
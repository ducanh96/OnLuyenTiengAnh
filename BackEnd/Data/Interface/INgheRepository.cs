using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PracticeEnglish.Models;
using PracticeEnglish.Contracts.Request;

namespace PracticeEnglish.Data.Interface
{
    public interface INgheRepository
    {
        Task<IEnumerable<Nghe>> LayDSFileNghe(GetListFileNgheRequest r);
        Task<int> ThemFileNghe(ThemFileNgheRequest r);
        Task<int> SuaFileNghe(SuaFileNgheRequest r);
        Task<bool> XoaFileNghe(XoaFileNgheRequest r);
    }
}
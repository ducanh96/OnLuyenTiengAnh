using PracticeEnglish.Contracts.Request;
using PracticeEnglish.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeEnglish.Business.Interface
{
    public interface INgheBusiness
    {
        Task<IEnumerable<NgheEntity>> GetDSNghe_CauHoi(int maTopic);
        Task<string> GetMusic(int idDeThi);
        Task<int> Add(ThemFileNgheRequest r);
        Task<int> Update(SuaFileNgheRequest r);
        Task<bool> Delete(XoaFileNgheRequest r);
    }
}

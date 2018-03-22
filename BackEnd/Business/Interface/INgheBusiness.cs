using PracticeEnglish.Contracts.Request;
using PracticeEnglish.Contracts.Response;
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
        Task<AddResponse> Add(ThemFileNgheRequest r);
        Task<AddResponse> Update(SuaFileNgheRequest r);
        Task<bool> Delete(XoaFileNgheRequest r);
    }
}

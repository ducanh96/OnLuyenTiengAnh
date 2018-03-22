using PracticeEnglish.Contracts.Request;
using PracticeEnglish.Contracts.Response;
using PracticeEnglish.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeEnglish.Business.Interface
{
    public interface IDocBusiness
    {
        Task<IEnumerable<DocEntity>> GetDSDoc_CauHoi(int maTopic);
        Task<string> GetParagraph(int idDeThi);
        Task<AddResponse> Add(ThemDoanVanRequest r);
        Task<AddResponse> Update(SuaDoanVanRequest r);
        Task<bool> Delete(XoaDoanVanRequest r);
    }
}

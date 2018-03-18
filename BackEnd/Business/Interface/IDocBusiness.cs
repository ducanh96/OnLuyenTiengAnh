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
    }
}

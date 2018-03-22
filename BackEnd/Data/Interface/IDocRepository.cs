using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PracticeEnglish.Models;
using PracticeEnglish.Contracts.Request;
using PracticeEnglish.Contracts.Response;

namespace PracticeEnglish.Data.Interface
{
    public interface IDocRepository
    {
        Task<IEnumerable<Doc>> LayDSDoanVan(int idChuDe);
        Task<string> GetParagraph(int idDeThi);
        Task<IEnumerable<Doc>> LayDSDoanVan(GetListDoanVanRequest r);
        Task<AddResponse> ThemDoanVan(ThemDoanVanRequest r);
        Task<AddResponse> SuaDoanVan(SuaDoanVanRequest r);
        Task<bool> XoaDoanVan(XoaDoanVanRequest r);
       
    }
}
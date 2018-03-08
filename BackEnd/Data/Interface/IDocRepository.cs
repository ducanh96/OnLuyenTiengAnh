using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PracticeEnglish.Models;

namespace PracticeEnglish.Data.Interface
{
    public interface IDocRepository
    {
        Task<IEnumerable<Doc>> LayDSDoanVan(int idChuDe);
        Task<int> ThemDoanVan(Doc doc);
        Task<int> SuaDoanVan(Doc doc);
        Task<bool> XoaDoanVan(int id);
       
    }
}
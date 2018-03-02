using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PracticeEnglish.Models;

namespace PracticeEnglish.Data.Interface
{
    public interface IDeThiRepository
    {
        Task<IEnumerable<DeThi>> GetListDeThi_ChuDe(int id);
      
    }
}
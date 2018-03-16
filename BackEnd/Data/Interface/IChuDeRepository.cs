using PracticeEnglish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeEnglish.Data.Interface
{
    public interface IChuDeRepository
    {
        Task<IEnumerable<ChuDe>> Gets();
    }
}

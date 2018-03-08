using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeEnglish.Contracts.Request;
using PracticeEnglish.Contracts.Response;

namespace PracticeEnglish.Business.Interface
{
    public interface IChuDeBusiness
    {
        Task<ChuDeGetsResponse> Gets();
    }
}

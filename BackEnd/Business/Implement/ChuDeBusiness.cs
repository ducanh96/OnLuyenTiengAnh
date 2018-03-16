using PracticeEnglish.Business.Interface;
using PracticeEnglish.Contracts.Request;
using PracticeEnglish.Contracts.Response;
using PracticeEnglish.Data.Interface;
using PracticeEnglish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeEnglish.Business.Implement
{
    public class ChuDeBusiness : IChuDeBusiness
    {
        private readonly IChuDeRepository _chuDeRepository;
        public ChuDeBusiness(IChuDeRepository chuDeRepository)
        {
            this._chuDeRepository = chuDeRepository;
        }

        public async Task<ChuDeGetsResponse> Gets()
        {
            ChuDeGetsResponse response = new ChuDeGetsResponse();
            IEnumerable<ChuDe> listChuDe = await _chuDeRepository.Gets();
            if (listChuDe.ToList().Count == 0)
            {
                response.Message = "Chủ đề không được tìm thấy";
            }
            else
            {
                response.ChuDes.AddRange(listChuDe);
            }

            return response;
        }
    }
}

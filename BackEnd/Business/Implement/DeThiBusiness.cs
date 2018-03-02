using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeEnglish.Business.Interface;
using PracticeEnglish.Contracts.Request;
using PracticeEnglish.Contracts.Response;
using PracticeEnglish.Data.Interface;
using PracticeEnglish.Models;

namespace PracticeEnglish.Business.Implement
{
    public class DeThiBussiness : IDeThiBusiness
    {
        private readonly IDeThiRepository _deThiRepository;
        public DeThiBussiness(IDeThiRepository deThiRepository)
        {
            this._deThiRepository = deThiRepository;
        }
        public async Task<DeThiGetListResponse> GetListDeThi_ChuDe(DeThiGetListRequest request)
        {
            DeThiGetListResponse response = new DeThiGetListResponse();
            IEnumerable<DeThi> listDeThi = await _deThiRepository.GetListDeThi_ChuDe(request.idTopic);
             if(listDeThi.ToList().Count == 0)
            {
                response.Message = "Đề thi không được tìm thấy";
            }
            else
            {
                response.DeThis.AddRange(listDeThi);
            }

            return response;
        }

       
    }
}
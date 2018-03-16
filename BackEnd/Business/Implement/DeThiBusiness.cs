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

        public async Task<DeThiAddResponse> Add(DeThiAddRequest deThiRequest)
        {
           return await _deThiRepository.Add(deThiRequest.deThi);
        }

        public async Task<int> GetLastId(string table)
        {
           return await _deThiRepository.GetLastId(table);
        }

        public async Task<DeThiAddResponse> UpdateCauHoi_DeThi(UpdateCauHoi_DeThiRequest request)
        {
            return await _deThiRepository.UpdateCauHoi_DeThi(request.IDCauHoi,request.IDDeThi);
        }
    }
}
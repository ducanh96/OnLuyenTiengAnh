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
    public class CauHoiBusiness : ICauHoiBusiness
    {
        private readonly ICauHoiRepository _cauHoiRepository;
        public CauHoiBusiness(ICauHoiRepository cauHoiRepository)
        {
            this._cauHoiRepository = cauHoiRepository;
        }
        public async Task<CauHoiGetListResponse> GetListCauHoi_KhongThuocDeThi(GetListCauHoiRequest r)
        {
            CauHoiGetListResponse response = new CauHoiGetListResponse();
            IEnumerable<CauHoi> listCauHoi = await _cauHoiRepository.GetListCauHoi_KhongThuocDeThi(r.idTopic);
            if (listCauHoi.ToList().Count == 0)
            {
                response.Message = "Câu hỏi không được tìm thấy";
            }
            else
            {
                response.CauHois.AddRange(listCauHoi);
            }

            return response;
        }
    }
}
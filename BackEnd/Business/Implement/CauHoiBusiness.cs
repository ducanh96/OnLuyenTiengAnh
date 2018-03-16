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
        public async Task<CauHoiGetListResponse> GetListCauHoiByID(GetListCauHoiRequest r)
        {
            CauHoiGetListResponse response = new CauHoiGetListResponse();
            IEnumerable<CauHoi> listCauHoi = await _cauHoiRepository.GetListCauHoi(r);
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
        public async Task<int> Add(ThemCauHoiRequest r)
        {
           return await _cauHoiRepository.ThemCauHoi(r);
        }
        public async Task<int> Update(SuaCauHoiRequest r)
        {
           return await _cauHoiRepository.SuaCauHoi(r);
        }
        public async Task<bool> Delete(XoaCauHoiRequest r)
        {
           return await _cauHoiRepository.XoaCauHoi(r);
        }
        public async Task<bool> DeleteByIDDoc(XoaCauHoiByIDDocRequest r)
        {
           return await _cauHoiRepository.XoaCauHoiByIdDoc(r);
        }
        public async Task<bool> DeleteByIDNghe(XoaCauHoiByIDNgheRequest r)
        {
           return await _cauHoiRepository.XoaCauHoiByIdNghe(r);
        }
    }
}
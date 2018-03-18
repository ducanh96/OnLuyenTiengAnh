using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PracticeEnglish.Contracts;
using PracticeEnglish.Contracts.Request;
using PracticeEnglish.Contracts.Response;
using PracticeEnglish.Models;
namespace PracticeEnglish.Business.Interface
{
    public interface ICauHoiBusiness
    {
       Task<CauHoiGetListResponse> GetListCauHoi_KhongThuocDeThi(GetListCauHoiRequest r);
       Task<GetListCauHoi_DeThiResponse> GetListCauHoi_DeThi(GetListCauHoi_DeThiRequest r);
    }
}
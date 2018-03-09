using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeEnglish.Business;
using PracticeEnglish.Contracts.Response;
using PracticeEnglish.Data;
using PracticeEnglish.Models;
using Microsoft.AspNetCore.Mvc;
using PracticeEnglish.Business.Interface;
using PracticeEnglish.Contracts.Request;

namespace PracticeEnglish.Controllers
{
    [Route("api/v1/[controller]")]
    public class CauHoiController : Controller
    {
        private readonly ICauHoiBusiness _cauHoiBusiness;

        public CauHoiController(ICauHoiBusiness cauHoiBusiness)
        {
            _cauHoiBusiness = cauHoiBusiness;
        }

        // GET api/v1/category/{id}
        [HttpGet("{idTopic}")]
        public async Task<CauHoiGetListResponse> GetListCauHoi_KhongThuocDeThi(GetListCauHoiRequest request)
        {
            return await _cauHoiBusiness.GetListCauHoi_KhongThuocDeThi(request);
        }

      

        
    }
}
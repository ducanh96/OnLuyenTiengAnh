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
using PracticeEnglish.Entity;

namespace PracticeEnglish.Controllers
{
    [Route("api/v1/[controller]")]
    public class CauHoiController : Controller
    {
        private readonly ICauHoiBusiness _cauHoiBusiness;
        private readonly INgheBusiness _ngheBusiness;
        private readonly IDocBusiness _docBusiness;

        public CauHoiController(ICauHoiBusiness cauHoiBusiness,INgheBusiness ngheBusiness,IDocBusiness docBusiness)
        {
            _cauHoiBusiness = cauHoiBusiness;
            _ngheBusiness = ngheBusiness;
            _docBusiness = docBusiness;
        }

        // GET api/v1/category/{id}
        [HttpGet("{idTopic}")]
        public async Task<CauHoiGetListResponse> GetListCauHoi_KhongThuocDeThi(GetListCauHoiRequest request)
        {
            return await _cauHoiBusiness.GetListCauHoi_KhongThuocDeThi(request);
        }


        [HttpGet("Nghe/{idTopic}")]
        public async Task<IEnumerable<NgheEntity>> GetDSNghe_CauHoi(int idTopic)
        {
            return await _ngheBusiness.GetDSNghe_CauHoi(idTopic);
        }

        [HttpGet("Doc/{idTopic}")]
        public async Task<IEnumerable<DocEntity>> GetDSDoc_CauHoi(int idTopic)
        {
            return await _docBusiness.GetDSDoc_CauHoi(idTopic);
        }


        [HttpGet("{idDeThi}")]
        public async Task<GetListCauHoi_DeThiResponse> GetListCauHoi_DeThi(GetListCauHoi_DeThiRequest request)
        {
            return await _cauHoiBusiness.GetListCauHoi_DeThi(request);
        }


    }
}
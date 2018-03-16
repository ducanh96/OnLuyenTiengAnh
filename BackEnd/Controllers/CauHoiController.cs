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

        public CauHoiController(ICauHoiBusiness cauHoiBusiness,INgheBusiness ngheBusiness)
        {
            _cauHoiBusiness = cauHoiBusiness;
            _ngheBusiness = ngheBusiness;
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

        [ProducesResponseType(201)]
        [HttpPost]
        public async Task<int> AddCauHoi([FromBody]ThemCauHoiRequest r)
        {
            return await _cauHoiBusiness.Add(r);
        }
        [ProducesResponseType(201)]
        [HttpPut("UpdateCauHoi")]
        public async Task<int> UpdateCauHoi([FromBody]SuaCauHoiRequest request)
        {
            return await _cauHoiBusiness.Update(request);
        }
        [ProducesResponseType(201)]
        [HttpDelete("DeleteCauHoi")]
        public async Task<bool> DeleteCauHoi([FromBody]XoaCauHoiRequest request)
        {
            return await _cauHoiBusiness.Delete(request);
        }
         [ProducesResponseType(201)]
        [HttpDelete("DeleteCauHoiByIDDoc")]
        public async Task<bool> DeleteCauHoiByIDDoc([FromBody]XoaCauHoiByIDDocRequest request)
        {
            return await _cauHoiBusiness.DeleteByIDDoc(request);
        }
         [ProducesResponseType(201)]
        [HttpDelete("DeleteCauHoiByIDNghe")]
        public async Task<bool> DeleteCauHoiByIDNghe([FromBody]XoaCauHoiByIDNgheRequest request)
        {
            return await _cauHoiBusiness.DeleteByIDNghe(request);
        }
    }
}
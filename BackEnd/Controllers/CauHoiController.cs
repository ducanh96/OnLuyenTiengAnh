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
        //[HttpGet("{idTopic}")]
        [HttpGet("KhongThuocDeThi/{idTopic}")]
        public async Task<CauHoiGetListResponse> GetListCauHoi_KhongThuocDeThi(GetListCauHoiRequest request)
        {
            return await _cauHoiBusiness.GetListCauHoi_KhongThuocDeThi(request);
        }

        [HttpGet("get/{idTopic}")]
        public async Task<CauHoiGetListResponse> GetListCauHoiByID(GetListCauHoiRequest request)
        {
            return await _cauHoiBusiness.GetListCauHoiByID(request);
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


        [ProducesResponseType(201)]
        [HttpPost]
        public async Task<AddResponse> AddCauHoi([FromBody]ThemCauHoiRequest r)
        {
            return await _cauHoiBusiness.Add(r);
        }
        [ProducesResponseType(201)]
        [HttpPut("UpdateCauHoi")]
        public async Task<AddResponse> UpdateCauHoi([FromBody]SuaCauHoiRequest request)
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
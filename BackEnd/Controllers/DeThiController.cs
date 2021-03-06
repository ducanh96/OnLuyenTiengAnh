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
    public class DeThiController : Controller
    {
        private readonly IDeThiBusiness _deThiBusiness;

        public DeThiController(IDeThiBusiness deThiBusiness)
        {
            _deThiBusiness = deThiBusiness;
        }

        // GET api/v1/category/{id}
        [HttpGet("{idTopic}")]
        public async Task<DeThiGetListResponse> GetListDeThi_ChuDe(DeThiGetListRequest request)
        {
            return await _deThiBusiness.GetListDeThi_ChuDe(request);
        }

        
        [ProducesResponseType(201)]
        [HttpPost]
        public async Task<DeThiAddResponse> AddDeThi([FromBody]DeThiAddRequest deThi)
        {
            return await _deThiBusiness.Add(deThi);
        }
      
        [HttpGet("GetLastId")]
         public async Task<int> GetLastId([FromQuery]string table)
        {
            return await _deThiBusiness.GetLastId(table);
        }

        [ProducesResponseType(201)]
        [HttpPut("UpdateCauHoi")]
        public async Task<DeThiAddResponse> UpdateCauHoi_DeThi([FromBody]UpdateCauHoi_DeThiRequest request)
        {
            return await _deThiBusiness.UpdateCauHoi_DeThi(request);
        }

        [HttpGet("Get/{idDeThi}")]
        public async Task<GetDeThiByIdResponse> GetDeThiById(GetDeThiByIdRequest request)
        {
            return await _deThiBusiness.GetDeThiById(request);
        }

    }
}
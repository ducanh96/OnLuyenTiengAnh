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

      

        
    }
}
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
    public class ChuDeController:Controller
    {
        private readonly IChuDeBusiness _chuDeBusiness;

        public ChuDeController(IChuDeBusiness chuDeBusiness)
        {
            _chuDeBusiness = chuDeBusiness;
        }

        // GET api/v1/category
        [HttpGet]
        public async Task<ChuDeGetsResponse> Gets()
        {
            return await _chuDeBusiness.Gets();
        }
    }
}

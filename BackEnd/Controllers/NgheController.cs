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
    public class NgheController : Controller
    {
        private readonly INgheBusiness _ngheBusiness;

        public NgheController(INgheBusiness ngheBusiness)
        {
            _ngheBusiness = ngheBusiness;
        }

        // GET api/v1/category/{id}
        [HttpGet("{idDeThi}")]
        public async Task<IActionResult> GetMusic(int idDeThi)
        {
            return Json(await _ngheBusiness.GetMusic(idDeThi));
        }
        
[ProducesResponseType(201)]
        [HttpPost]
          public async Task<AddResponse> Add([FromBody]ThemFileNgheRequest r)
        {
            return await _ngheBusiness.Add(r);
        }
        [ProducesResponseType(201)]
        [HttpPut("UpdateNghe")]
        public async Task<AddResponse> Update([FromBody]SuaFileNgheRequest request)
        {
            return await _ngheBusiness.Update(request);
        }
        [ProducesResponseType(201)]
        [HttpDelete("DeleteNghe")]
        public async Task<bool> Delete([FromBody]XoaFileNgheRequest request)
        {
            return await _ngheBusiness.Delete(request);
        }
       
    }
}
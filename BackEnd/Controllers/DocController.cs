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
    public class DocController : Controller
    {
        private readonly IDocBusiness _docBusiness;

        public DocController(IDocBusiness docBusiness)
        {
            _docBusiness = docBusiness;
        }

        // GET api/v1/category/{id}
        [HttpGet("{idDeThi}")]
        public async Task<IActionResult> GetParagraph(int idDeThi)
        {
            return Json(await _docBusiness.GetParagraph(idDeThi));
        }

        [ProducesResponseType(201)]
        [HttpPost]
        public async Task<AddResponse> Add([FromBody]ThemDoanVanRequest r)
        {
            return await _docBusiness.Add(r);
        }
        [ProducesResponseType(201)]
        [HttpPut("UpdateDoc")]
        public async Task<AddResponse> Update([FromBody]SuaDoanVanRequest request)
        {
            return await _docBusiness.Update(request);
        }
        [ProducesResponseType(201)]
        [HttpDelete("DeleteDoc")]
        public async Task<bool> Delete([FromBody]XoaDoanVanRequest request)
        {
            return await _docBusiness.Delete(request);
        }
       

    }
}
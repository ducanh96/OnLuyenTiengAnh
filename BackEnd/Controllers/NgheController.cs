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

        
       

    }
}
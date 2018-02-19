using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcore_rest_api_with_dapper.Business;
using aspnetcore_rest_api_with_dapper.Contracts;
using aspnetcore_rest_api_with_dapper.Data;
using aspnetcore_rest_api_with_dapper.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore_rest_api_with_dapper.Controllers
{
    [Route("api/v1/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryBusiness _categoryBusiness;

        public CategoryController(ICategoryBusiness categoryBusiness)
        {
            _categoryBusiness = categoryBusiness;
        }

        // GET api/v1/category/{id}
        [HttpGet("{id}")]
        public async Task<CategoryResponse> Get(long id)
        {
            return await _categoryBusiness.GetAsync(id);
        }

        // GET api/v1d/category
        [HttpGet]
        public async Task<CategoryResponse> Get()
        {
            return await _categoryBusiness.GetAllAsync();
        }

        
    }
}
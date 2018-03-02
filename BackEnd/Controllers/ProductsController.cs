using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeEnglish.Business;
using PracticeEnglish.Contracts.Response;
using PracticeEnglish.Contracts.Request;
using PracticeEnglish.Data;
using PracticeEnglish.Models;
using Microsoft.AspNetCore.Mvc;
using PracticeEnglish.Business.Interface;

namespace PracticeEnglish.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductBusiness _productBusiness;

        public ProductsController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        // GET api/v1/products/{id}
        [HttpGet("{id}")]
        public async Task<ProductResponse> Get(long id)
        {
            return await _productBusiness.GetAsync(id);
        }

        // GET api/v1/products
        [HttpGet]
        public async Task<ProductResponse> Get()
        {
            return await _productBusiness.GetAllAsync();
        }

        // POST api/v1/products
        [ProducesResponseType(201)]
        [HttpPost]
        public async Task Post([FromBody]ProductRequest productRequest)
        {
            await _productBusiness.AddAsync(productRequest);
        }
    }
}
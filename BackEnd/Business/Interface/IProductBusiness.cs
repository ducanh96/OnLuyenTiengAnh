using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PracticeEnglish.Contracts.Response;
using PracticeEnglish.Contracts.Request;
using PracticeEnglish.Models;

namespace PracticeEnglish.Business.Interface
{
    public interface IProductBusiness
    {
        Task<ProductResponse> GetAsync(long id);
        Task<ProductResponse> GetAllAsync();
        Task AddAsync(ProductRequest productRequest);
    }
}
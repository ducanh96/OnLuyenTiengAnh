using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PracticeEnglish.Contracts.Response;
using PracticeEnglish.Contracts.Request;
using PracticeEnglish.Models;

namespace PracticeEnglish.Business.Interface
{
    public interface ICategoryBusiness
    {
        Task<CategoryResponse> GetAsync(long id);
        Task<CategoryResponse> GetAllAsync();
        
    }
}
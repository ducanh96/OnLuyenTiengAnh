using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetcore_rest_api_with_dapper.Models;

namespace aspnetcore_rest_api_with_dapper.Data
{
    public interface ICategoryRepository
    {
        Task<Category> GetAsync(long id);
        Task<IEnumerable<Category>> GetAllAsync();
        
    }
}
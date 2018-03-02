using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PracticeEnglish.Models;

namespace PracticeEnglish.Data.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> GetAsync(long id);
        Task<IEnumerable<Category>> GetAllAsync();
        
    }
}
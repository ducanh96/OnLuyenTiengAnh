using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeEnglish.Contracts.Response;
using PracticeEnglish.Contracts.Request;
using PracticeEnglish.Data;
using PracticeEnglish.Models;
using PracticeEnglish.Data.Interface;
using PracticeEnglish.Business.Interface;

namespace PracticeEnglish.Business.Implement
{
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryBusiness(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryResponse> GetAllAsync()
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            IEnumerable<Category> categories = await _categoryRepository.GetAllAsync();
            
            if(categories.ToList().Count == 0)
            {
                categoryResponse.Message = "Categories not found.";
            }
            else
            {
                categoryResponse.Categories.AddRange(categories);
            }

            return categoryResponse;
        }

        public async Task<CategoryResponse> GetAsync(long id)
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            Category category = await _categoryRepository.GetAsync(id);
            
            if(category == null)
            {
                categoryResponse.Message = "Category not found.";
            }
            else
            {
                categoryResponse.Categories.Add(category);
            }

            return categoryResponse;

        }

       
    }
}
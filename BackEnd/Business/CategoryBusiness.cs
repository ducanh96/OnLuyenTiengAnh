using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcore_rest_api_with_dapper.Contracts;
using aspnetcore_rest_api_with_dapper.Data;
using aspnetcore_rest_api_with_dapper.Models;

namespace aspnetcore_rest_api_with_dapper.Business
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
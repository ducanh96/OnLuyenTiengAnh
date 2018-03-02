using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PracticeEnglish.Models;

namespace PracticeEnglish.Data.Interface
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(long id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
         Task<IEnumerable<Product>> GetProductsWithById(long categoryId);
    }
}
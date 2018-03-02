using System;
using PracticeEnglish.Data;
using GraphQL.Types;
using PracticeEnglish.Data.Interface;

namespace PracticeEnglish.Models
{
     public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(ICategoryRepository categoryRepository)
        {
            Field(x => x.Id).Description("Product id.");
            Field(x => x.Name).Description("Product name.");
            Field(x => x.Description, nullable: true).Description("Product description.");
            Field(x => x.Price).Description("Product price.");
 
            Field<CategoryType>(
                "category", 
                resolve: context => categoryRepository.GetAsync(context.Source.CategoryId).Result
             );
        }
    }
}
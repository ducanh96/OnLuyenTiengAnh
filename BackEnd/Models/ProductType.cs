using System;
using aspnetcore_rest_api_with_dapper.Data;
using GraphQL.Types;

namespace aspnetcore_rest_api_with_dapper.Models
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
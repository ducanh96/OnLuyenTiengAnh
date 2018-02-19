using System;
using System.Collections.Generic;
using aspnetcore_rest_api_with_dapper.Data;
using GraphQL.Types;

namespace aspnetcore_rest_api_with_dapper.Models
{
    public class CategoryType:ObjectGraphType<Category>
    {
        public CategoryType(IProductRepository productRepository)
        {
            Field(x => x.Id).Description("Category id.");
            Field(x => x.Name, nullable: true).Description("Category name.");
 
            Field<ListGraphType<ProductType>>(
                "products", 
                resolve: context => productRepository.GetProductsWithById(context.Source.Id).Result
            );
        }
    }

}

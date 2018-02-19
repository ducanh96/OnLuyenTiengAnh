using System;
using aspnetcore_rest_api_with_dapper.Data;
using GraphQL.Types;

namespace aspnetcore_rest_api_with_dapper.Models
{
    public class EasyStoreQuery : ObjectGraphType
    {
        public EasyStoreQuery(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            Field<CategoryType>(
                "category",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "id", Description = "Category id"}
                ),
                resolve: context => categoryRepository.GetAsync(context.GetArgument<int>("id")).Result
            );
 
            Field<ProductType>(
                "product",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "id", Description = "Product id"}
                ),
                resolve: context => productRepository.GetAsync(context.GetArgument<int>("id")).Result
            );
        }
    }
}
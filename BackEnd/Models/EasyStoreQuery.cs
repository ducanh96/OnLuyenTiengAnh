using System;
using PracticeEnglish.Data;
using GraphQL.Types;
using PracticeEnglish.Data.Interface;

namespace PracticeEnglish.Models
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
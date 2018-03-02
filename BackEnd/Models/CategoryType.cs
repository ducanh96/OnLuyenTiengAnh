using System;
using System.Collections.Generic;
using PracticeEnglish.Data;
using GraphQL.Types;
using PracticeEnglish.Data.Interface;

namespace PracticeEnglish.Models
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

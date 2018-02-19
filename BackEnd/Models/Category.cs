using System;
using System.Collections.Generic;

namespace aspnetcore_rest_api_with_dapper.Models
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }

}

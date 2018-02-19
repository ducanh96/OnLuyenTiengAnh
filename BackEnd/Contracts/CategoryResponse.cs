using System;
using System.Collections.Generic;
using aspnetcore_rest_api_with_dapper.Models;
using Newtonsoft.Json;

namespace aspnetcore_rest_api_with_dapper.Contracts
{
    public class CategoryResponse
    {
        public CategoryResponse()
        {  
             Categories = new List<Category>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public List<Category> Categories { get; set; }
    }
}
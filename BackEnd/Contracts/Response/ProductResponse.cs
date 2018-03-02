using System;
using System.Collections.Generic;
using PracticeEnglish.Models;
using Newtonsoft.Json;

namespace PracticeEnglish.Contracts.Response
{
    public class ProductResponse
    {
        public ProductResponse()
        {  
             Products = new List<Product>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public List<Product> Products { get; set; }
    }
}
using System;
using System.Collections.Generic;
using PracticeEnglish.Models;
using Newtonsoft.Json;

namespace PracticeEnglish.Contracts.Response
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
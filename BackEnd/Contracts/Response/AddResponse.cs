using System;
using System.Collections.Generic;
using PracticeEnglish.Models;
using Newtonsoft.Json;

namespace PracticeEnglish.Contracts.Response
{
    public class AddResponse
    {
       public int Code { get; set; }  

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
       public string Message { get; set; }
        
    }
}
using System;
using System.Collections.Generic;
using PracticeEnglish.Models;
using Newtonsoft.Json;

namespace PracticeEnglish.Contracts.Response
{
    public class DeThiGetListResponse
    {
         public DeThiGetListResponse()
        {  
             DeThis = new List<DeThi>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public List<DeThi> DeThis { get; set; }
    }
}
using System;
using System.Collections.Generic;
using PracticeEnglish.Models;
using Newtonsoft.Json;

namespace PracticeEnglish.Contracts.Response
{
    public class CauHoiGetListResponse
    {
         public CauHoiGetListResponse()
        {  
             CauHois = new List<CauHoi>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public List<CauHoi> CauHois { get; set; }
    }
}
using Newtonsoft.Json;
using PracticeEnglish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeEnglish.Contracts.Response
{
    public class GetListCauHoi_DeThiResponse
    {
        public GetListCauHoi_DeThiResponse()
        {
            CauHois = new List<CauHoi>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        public DeThi deThi { get; set; }
        public List<CauHoi> CauHois { get; set; }

    }
}

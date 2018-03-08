using Newtonsoft.Json;
using PracticeEnglish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeEnglish.Contracts.Response
{
    public class ChuDeGetsResponse
    {
        public ChuDeGetsResponse()
        {
            ChuDes = new List<ChuDe>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public List<ChuDe> ChuDes { get; set; }
    }
}

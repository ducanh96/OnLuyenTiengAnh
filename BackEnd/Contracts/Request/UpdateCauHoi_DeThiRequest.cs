using System;
using System.Collections.Generic;
using PracticeEnglish.Models;

namespace PracticeEnglish.Contracts.Request
{
    public class UpdateCauHoi_DeThiRequest
    {
        public int IDCauHoi { get; set; }
        public int IDDeThi { get; set; }
    }
}
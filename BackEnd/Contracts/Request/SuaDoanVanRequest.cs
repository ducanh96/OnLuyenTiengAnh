using System;
using System.Collections.Generic;

namespace PracticeEnglish.Contracts.Request
{
    public class SuaDoanVanRequest
    {
        public int ID   { get; set; } 
        public string DoanVan { get; set; }
        public int IDChuDe   { get; set; } 
    }
}
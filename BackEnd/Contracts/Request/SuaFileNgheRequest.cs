using System;
using System.Collections.Generic;

namespace PracticeEnglish.Contracts.Request
{
    public class SuaFileNgheRequest
    {
        public int ID   { get; set; } 
        public string FileNghe { get; set; }
        public int IDChuDe   { get; set; } 
    }
}
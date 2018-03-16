using PracticeEnglish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeEnglish.Entity
{
    public class DocEntity
    {
        public Doc doc { get; set; }
        public List<CauHoi> CauHois { get; set; }
    }
}

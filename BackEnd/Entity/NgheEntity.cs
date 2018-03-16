using PracticeEnglish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeEnglish.Entity
{
    public class NgheEntity
    {
        public Nghe nghe { get; set; }
        public List<CauHoi> CauHois { get; set; }
    }
}

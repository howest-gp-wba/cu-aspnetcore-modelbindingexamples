using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.ModelBindingSamples.Models
{
    public class Sailor
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string NickName { get; set; }
        public int Legs { get; set; }
        public int? Age { get; set; }
        public bool IsCaptain { get; set; }
    }

}

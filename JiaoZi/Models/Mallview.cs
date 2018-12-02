using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class Mallview
    {
       
        public IEnumerable<Books> Price { get; set; }
        public IEnumerable<Books> Chinese { get; set; }
        public IEnumerable<Books> Math { get; set; }
        public IEnumerable<Books> English { get; set; }
        public IEnumerable<Books> Art { get; set; }
        public IEnumerable<Books> Political { get; set; }
        public IEnumerable<Books> Pedagogy { get; set; }
        public IEnumerable<Books> Synthesize { get; set; }
        public IEnumerable<Books> Chemistry { get; set; }
        public IEnumerable<Books> History { get; set; }
        public IEnumerable<Books> Interview { get; set; }
        public IEnumerable<Books> Psychic { get; set; }
        public IEnumerable<Books> Search { get; set; }
        public IEnumerable<Books> Hotsale { get; set; }
        public IEnumerable<Books> Onsale { get; set; }
    }
}
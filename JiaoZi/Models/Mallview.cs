using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class Mallview
    {
        internal IEnumerable<Books> price;

        public IEnumerable<Books> Price{ get; set; }
        public IEnumerable<Books> English { get; set; }
        public IEnumerable<Books>  Putonguha{ get; set; }
        public IEnumerable<Books> Mate { get; set; }
        public IEnumerable<Books> Putonghua { get; internal set; }
    }
}
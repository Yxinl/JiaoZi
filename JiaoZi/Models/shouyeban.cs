using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class shouyeban
    {
        public IEnumerable<Books> Newissuebook { get; set; }
        public IEnumerable<News> newstops { get; set; }
        public IEnumerable<TextResource> newtextresource { get; set; }

    }
}
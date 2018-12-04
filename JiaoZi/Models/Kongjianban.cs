using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class Kongjianban
    {
        //该用户所有的说说
        public IEnumerable<Shuoshuo> UserAllShuo { get; set; }
    }
}
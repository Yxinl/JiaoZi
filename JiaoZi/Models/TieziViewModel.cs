using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class TieziViewModel
    {
        public IEnumerable<Remarks> Gettiezi { get; set; }
        public IEnumerable<RemarkComments> Getpinglun { get; set; }
        public IEnumerable<RemarkReply> Gethuifu { get; set; }
    }
}
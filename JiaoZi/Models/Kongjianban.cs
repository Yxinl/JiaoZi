﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class Kongjianban
    {
        //该用户所有的说说
        public IEnumerable<Shuoshuo> UserAllShuo { get; set; }
       //说说的评论
        public IEnumerable<ShuoshuoComment> ShuoCommentById { get; set; }
        //发说说
        public Shuoshuo sendshuo { get; set; }
        //用户上传过的所有文件
        public IEnumerable<Text> userupload{ get; set; }
    }
}
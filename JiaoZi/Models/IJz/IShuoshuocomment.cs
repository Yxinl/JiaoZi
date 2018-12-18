using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaoZi.Models
{
    interface IShuoshuocomment
    {
        //通过说说id找全部评论
        IQueryable<ShuoshuoComment> ShuoCommentById(int shuoid);
    }
}

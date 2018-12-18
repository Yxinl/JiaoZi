using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{

    public class RShuoshuocomment:IShuoshuocomment
    {
        protected jiaoziEntities db = new jiaoziEntities();
        IQueryable<ShuoshuoComment> IShuoshuocomment.ShuoCommentById(int shuoid)
        {
            return db.ShuoshuoComment.Where(b => b.ShuoshuoID == shuoid);
        }
    }
}
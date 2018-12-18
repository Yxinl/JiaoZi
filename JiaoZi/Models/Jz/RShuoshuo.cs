using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class RShuoshuo:IShuoshuo
    {
        protected jiaoziEntities db = new jiaoziEntities();
        IQueryable<Shuoshuo> IShuoshuo.AllShuoByID(int id)
        {
            return db.Shuoshuo.Where(b => b.UserID == id);
        }
    }
}
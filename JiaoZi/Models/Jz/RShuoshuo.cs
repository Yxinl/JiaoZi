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
            //return db.Shuoshuo.Where(b => b.UserID == id);
            return db.Shuoshuo.OrderByDescending(o => o.Shuoshuo_Time).Where(b => b.UserID == id);
        }
        void IShuoshuo.Add(Shuoshuo shuoshuo)
        {
            db.Shuoshuo.Add(shuoshuo);
            db.SaveChanges();     
        }
    }
}
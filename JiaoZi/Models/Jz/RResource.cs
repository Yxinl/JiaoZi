using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class RResource:IResource
    {
        protected jiaoziEntities db = new jiaoziEntities();
        IQueryable<TextResource> IResource.ResourceByTime(int a, int b)
        {
            var resource =
                from o in db.TextResource
                orderby o.Text_Time
                select o;
            //foreach (var news in news1)
            return resource.Skip(a).Take(b);

        }
    }
}
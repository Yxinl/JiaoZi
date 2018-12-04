using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaoZi.Models
{
    interface IResource
    {
        IQueryable<TextResource> ResourceByTime(int a, int b);

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaoZi.Models.IJz
{
    interface IMall
    {
        IEnumerable<Books> GetBooks();

    }
}

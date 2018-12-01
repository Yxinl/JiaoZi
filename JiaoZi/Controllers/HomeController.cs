using JiaoZi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JiaoZi.Controllers
{
    public class HomeController : Controller
    {
        jiaoziEntities db = new jiaoziEntities();

       //测试用的首页
        public ActionResult Page()
        {
            var list = db.Users;
            return View(list);
        }
    }
}
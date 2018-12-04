using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JiaoZi.Models;
using System.IO;

namespace JiaoZi.Controllers
{
    public class KongjianController : Controller
    {
        Models.jiaoziEntities db = new Models.jiaoziEntities();
        IShuoshuo shuo = new RShuoshuo();
        Kongjianban kongjianban = new Kongjianban();
        // GET: Kongjian
        public ActionResult Index()
        {
            return View();
        }
        //用户发表过的所有说说
        public ActionResult shuoshuo()
        {
            //id要改为用户id
            var usershuoshuo = shuo.AllShuoByID(1);
            kongjianban.UserAllShuo = usershuoshuo;
            return View(kongjianban);
        }

        //文件上传
        public ActionResult File()
        {
            return View();
        }
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {

            var fileName = file.FileName;
            var filePath = Server.MapPath(string.Format("~/{0}", "Images"));
            file.SaveAs(Path.Combine(filePath, fileName));
            return View();
        }

    }
}
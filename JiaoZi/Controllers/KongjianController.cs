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
        IShuoshuocomment shuocomment = new RShuoshuocomment();
        Kongjianban kongjianban = new Kongjianban();
        // GET: Kongjian
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult shiyan()
        {
            return View();
        }
        //说说
        public ActionResult shuoshuo()
        {
            //通过用户id找说说
            //var usershuoshuo = shuo.AllShuoByID(Convert.ToInt32(Session["User_id"]));
            //便于测试
            var usershuoshuo = shuo.AllShuoByID(1);
            //通过说说id找说说评论
            var shuoshuocomment = shuocomment.ShuoCommentById(1);
            kongjianban.UserAllShuo = usershuoshuo;
            kongjianban.ShuoCommentById = shuoshuocomment;
            return View(kongjianban);
        }
        ////发表说说
        //public ActionResult sendshuoshuo()
        //{
        //    return View();
        //}
        [HttpPost]
        public ActionResult shuoshuo(Shuoshuo shuoshuo)
        {
            string shuoshuotextarea = Request["shuoshuoinput"];
            try { 
            if (ModelState.IsValid)
            {
                shuoshuo.Shuoshuo_Content = shuoshuotextarea;
                shuoshuo.Shuoshuo_Time = DateTime.Now;
                shuoshuo.Thumb_Num = 0;
                //shuoshuo.UserID = Convert.ToInt32(Session["User_id"]);
                //便于测试
                shuoshuo.UserID = 1;
                shuo.Add(shuoshuo);
                db.SaveChanges();
                    return View(kongjianban);
            }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return RedirectToAction("shuoshuo", "Kongjian");
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
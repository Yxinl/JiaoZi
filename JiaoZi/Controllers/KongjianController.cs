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
        IText itext = new RText();
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
            return PartialView(kongjianban);
        }
        //发表说说
        public ActionResult sendshuoshuo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult sendshuoshuo(Shuoshuo shuoshuo)
        {
            string shuoshuotextarea = Request["shuoshuoinput"];
            try
            {
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
                    return PartialView(kongjianban);

                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return RedirectToAction("shuoshuo");
        }
       
        public ActionResult File()
        {
            var useruploadfile = itext.UserUploadText(1);
            kongjianban.userupload = useruploadfile;
            return PartialView(kongjianban);
        }

        /// <summary>
        /// 上传文件到项目
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult File(HttpPostedFileBase file, Text text)
        {
            //存入项目
            var fileName = file.FileName;
            var filePath = Server.MapPath(string.Format("~/{0}", "images/Kongjian/text"));
            var newfilePath = Path.Combine(filePath, fileName);
            file.SaveAs(newfilePath);
            //保存至数据库
            try
            {
                if (ModelState.IsValid)
                {
                    text.Text_path = newfilePath;
                    text.Text_Time = DateTime.Now;
                    //后期改成 file.UserID = Convert.ToInt32(Session["User_id"]);
                    text.UserID = 1;
                    itext.addtext(text);
                    db.SaveChanges();
                    return PartialView(kongjianban);
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            //存在问题，后期需要改成显示上传成功，跳转回原页面
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 上传至数据库
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        //[HttpPost]
        //public ActionResult addFile(Text text)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            text.Text_path = Convert.ToString(Session["filename"]);
        //            text.Text_Time = DateTime.Now;
        //            //后期改成 file.UserID = Convert.ToInt32(Session["User_id"]);
        //            text.UserID = 1;
        //            itext.addtext(text);
        //            db.SaveChanges();
        //            return PartialView(kongjianban);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content(ex.Message);
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
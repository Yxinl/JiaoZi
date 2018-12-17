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
        IVideo ivideo = new RVideo();
        Kongjianban kongjianban = new Kongjianban();
        // GET: Kongjian
        public ActionResult Index()
        {  
            return View();
        }
        /// <summary>
        /// 说说
        /// </summary>
        /// <returns></returns>
        public ActionResult shuoshuo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult shuoshuo(Shuoshuo shuoshuo)
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
        //列出所有的说说
        public ActionResult allshuoshuo()
        {
            //通过用户id找说说
            //var usershuoshuo = shuo.AllShuoByID(Convert.ToInt32(Session["User_id"]));
            //便于测试
            var usershuoshuo = shuo.AllShuoByID(1);
            //通过说说id找说说评论
           
            kongjianban.UserAllShuo = usershuoshuo;
           
            return PartialView(kongjianban);
        }
        //说说评论分部视图
        public ActionResult shuoshuocomment(int shuoshuoid)
        {
            Session["shuoshuoid1"] = shuoshuoid;
            var shuoshuocomment1 = shuocomment.ShuoCommentById(shuoshuoid);
            kongjianban.ShuoCommentById = shuoshuocomment1;
            return PartialView(kongjianban);
        }
        [HttpPost]
        public ActionResult shuoshuocomment()
        {
            string commentcontent = Request["commentcontent"];
            ShuoshuoComment comment = new ShuoshuoComment();
            try
            {
                if (ModelState.IsValid)
                {
                    comment.Comment_Content = commentcontent;
                    comment.Comment_Time = DateTime.Now;
                    //session代替
                    comment.UserID = 1;
                    comment.ShuoshuoID = Convert.ToInt32(Session["shuoshuoid1"]);
                    shuocomment.addshuocomment(comment);
                    db.SaveChanges();
                    return PartialView(kongjianban);
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return RedirectToAction("shuoshuocomment");
        }
        /// <summary>
        /// 文件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult File()
        {
            return View();
        }
        //上传文件
        [HttpPost]
        public ActionResult File(HttpPostedFileBase file, Text text)
        {
            //存入项目
            var fileName = file.FileName;
            //string fileName =file.FileName.Replace(Convert.ToChar(DateTime.Now), Convert.ToChar(file.FileName));
            var filePath = Server.MapPath(string.Format("~/{0}", "images/Kongjian/text"));
            var newfilePath = Path.Combine(filePath,fileName);
            file.SaveAs(newfilePath);
            //保存至数据库
            try
            {
                if (ModelState.IsValid)
                {
                   
                    text.Text_path = newfilePath;
                    text.Text_Time = DateTime.Now;
                    //后期改成 text.UserID = Convert.ToInt32(Session["User_id"]);
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
            return View();
        }
        //查找所有文件
        public ActionResult allfill()
        {
            var useruploadfile = itext.UserUploadText(1);
            kongjianban.userupload = useruploadfile;
            return PartialView(kongjianban);
        }
        /// <summary>
        /// 视频
        /// </summary>
        /// <returns></returns>
        public ActionResult video()
        {
            return View();
        }
        [HttpPost]
        public ActionResult video(HttpPostedFileBase file,Video video)
        {
            //存入项目
            var videoName = file.FileName;
            //string fileName =file.FileName.Replace(Convert.ToChar(DateTime.Now), Convert.ToChar(file.FileName));
            var videoPath = Server.MapPath(string.Format("~/{0}", "Video/"));
            var newvideoPath = Path.Combine(videoPath, videoName);
            file.SaveAs(newvideoPath);
            //保存至数据库
            try
            {
                if (ModelState.IsValid)
                {
                    //video名字获取传入存在问题，自动变成blob,视频上传自动分块
                    video.VideoPath = newvideoPath;
                    video.Video_Time = DateTime.Now;
                    //后期改成 video.UserID = Convert.ToInt32(Session["User_id"]);
                    video.UserID = 1;
                    video.downloadcount = 0;
                    ivideo.addvideo(video);
                    db.SaveChanges();
                    //return PartialView(kongjianban);
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return View();
        }
        public ActionResult allvideo()
        {
            //后期用 Convert.ToInt32(Session["User_id"])替换数字1
            var uservideo = ivideo.AllVideoByUserId(1);
            return PartialView(uservideo);
        }
    }
    
}
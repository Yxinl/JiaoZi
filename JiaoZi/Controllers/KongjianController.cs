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

        //文档
        public ActionResult File()
        {
            return View();
        }
        [HttpPost]
        public ActionResult File(FormCollection form)
        {
            //上传文件
            if (Request.Files.Count == 0)
            {
                //Request.Files.Count 文件数为0上传不成功
                return View();
            }
            var file = Request.Files[0];
            if (file.ContentLength == 0)
            {
                //文件大小大（以字节为单位）为0时，做一些操作
                return View();
            }
            else
            {
                //文件大小不为0
                file = Request.Files[0];
                //保存成自己的文件全路径,newfile就是你上传后保存的文件,
                //服务器上的UpLoadFile文件夹必须有读写权限
                string target = Server.MapPath("/") + ("/Mock/Learning/");//取得目标文件夹的路径
                string filename = file.FileName;//取得文件名字
                string path = target + filename;//获取存储的目标地址
                file.SaveAs(path);
            }
            return View();

        }

    }
}
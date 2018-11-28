using JiaoZi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JiaoZi.Controllers
{
    public class UserInfoController : Controller
    {
        jiaoziEntities db = new jiaoziEntities();
        IUserInfo iuser;
        public UserInfoController()
        {
            iuser = new UserInfo();                     //子类以父类的方式出现 ，多态
        }


        //首页
        public ActionResult Index()
        {
            return View();
        }

        //登录注册
        public ActionResult RegisteLogin()
        {
            return View();
        }

        //获取验证码
        public ActionResult GetImg()
        {
            int width = 100;
            int height = 40;
            int fontsize = 20;
            string code = string.Empty;
            byte[] bytes = Verify.CreateValidateGraphic(out code, 4, width, height, fontsize);
            Session["YZM"] = code;
            return File(bytes, @"image/jpeg");
        }


        //检查验证码
        public bool CheckYZM(string num)
        {
            string cnum = Session["YZM"] == null ? "" : Session["YZM"].ToString();

            if (num.ToLower() == cnum.ToLower() && !string.IsNullOrEmpty(num))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // 登录
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registe(string TrueName, string PasswordR, string Email)
        {
            var c = iuser.Registe(TrueName, PasswordR, Email);
            if (c)
            {
                var id = db.Users.Where(m => m.Email == Email).FirstOrDefault().UserID;
                return Content("<script>alert('注册成功！请记住您的ID：" + id + "');window.location.href='../Default/RL';</script>");
            }
            return Content("<script>alert('您的邮箱已被注册！请重试');history.go(-1);</script>");
        }



        [HttpPost]
        public ActionResult Login(int? UserID, string PasswordL, string YZM)
        {
            string data;
            var a = iuser.Login(UserID, PasswordL);
            var b = CheckYZM(YZM);
            if (a && !b)
            {
                return Content("<script>alert('验证码输入错误，请重试');history.go(-1);</script>");
            }
            else if (a && b)
            {
                Session["User_id"] = UserID;
                Session["User_image"] = db.Users.Where(m => m.UserID == UserID).FirstOrDefault().HeadImage;
                data = "登录成功";
                return Content(data);                                                          //有问题
                
            }
            else if (!a && b)
            {
                return Content("<script>alert('账号或密码输入错误，请重试');history.go(-1);</script>");
            }
            else
                return Content("<script>alert('请按照格式输入');history.go(-1);</script>");
        }



        //找回密码
        public ActionResult FindPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindPassword(string Email, string TrueName)
        {
            string password = iuser.FindPassword(Email, TrueName);
            return Content("<script>alert('" + password + "');window.location.href='../Default/RL';</script>");

        }




        //退出时头像（视图）的变化 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TX()
        {
            //try
            //{
            Session.Abandon();
            Session["User_id"] = null;
            Session["User_image"] = null;
            Session.Remove("User_id");
            //return PartialView();
            return RedirectToAction("Page","Home");    //退出返回首页
            //}

            //catch (Exception ex)
            //{
            //    return Content("ex");
            //}
        }
    }
}
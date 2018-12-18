using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JiaoZi.Models;

namespace JiaoZi.Controllers
{
    public class LuntanController : Controller
    {
        jiaoziEntities db = new jiaoziEntities();
        Models.TieziViewModel tieziviewmodel = new Models.TieziViewModel();

        // GET: Luntan
        public ActionResult Index()
        {
            IRemark_User_Comments_Reply ir = new RRemark_User_Comments_Reply();
          
                return View(ir.Getsall());
           
        }
        public ActionResult Index2(int id)
        {
            Session["Remarkid"] = id;
           IRemarks ir = new RRemarks();
            IRemarkcomments ire = new RRemarkcomments();
            ViewBag.Remarkid = id;

            //var remarkcomment = db.RemarkComments.OrderByDescending(p=>p.RemarkCommentID==id);
            var remarkreply = from o in db.RemarkReply
                              join b in db.RemarkComments on o.RemarkCommentID equals b.RemarkCommentID
                              join c in db.Remarks on b.RemarkID equals c.RemarkID
                              where c.RemarkID == id
                              select o;
            var ima_nam = from a in db.Users
                          join b in db.Remarks on a.UserID equals b.UserID
                          where a.UserID == id
                          select a;


            TieziViewModel tiz = new TieziViewModel()
            {
                Getpinglun = ire.Getcommentsbyid(id),
                Gethuifu = remarkreply,
                Gettiezi = ir.FindRemarksByID(id),
                GetIma_nam = ima_nam

            };
            return View(tiz);
      }
        //评论
        [HttpPost]
        [ValidateInput(false)]  //富文本编辑器使用
        [ValidateAntiForgeryToken]
       
        public ActionResult Pinglun(RemarkComments res)
        {
            IComments ic = new RComments(); 
            if(ModelState.IsValid)
            {
                int aa;
                res.Comment_Time = DateTime.Now;
                aa = System.Convert.ToInt32(Session["User_id"]);
                res.UserID = aa;
                ic.Comments(res);
                return Content("登录成功");
                //return "登录成功";


            }
            else
            {
                return Content("<script>alert('请先登录');window.location.href='../UserInfo/RegisteLogin';</script>");

            }

           
        }
        public ActionResult fatie ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult fatie(Remarks re)
        {
            IFatie ite = new RFatie();
            if (ModelState.IsValid)
            {
                //int aa;
            
                //aa = System.Convert.ToInt32(Session["User_id"]);
                ////res.UserID = aa;
                //re.UserID = aa;
                re.RemarkID = System.Convert.ToInt32(Session["User_id"]);
                db.SaveChanges();
                ite.publishremarks(re);
                return Content("发表成功");
               


            }
            else
            {
                return Content("<script>alert('请先登录');window.location.href='../UserInfo/RegisteLogin';</script>");

            }


            
        }
    }
}
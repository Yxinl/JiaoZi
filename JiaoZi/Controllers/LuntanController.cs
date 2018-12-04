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
           IRemarks ir = new RRemarks();
            IRemarkcomments ire = new RRemarkcomments();
        
            //var remarkcomment = db.RemarkComments.OrderByDescending(p=>p.RemarkCommentID==id);
            var remarkreply = db.RemarkReply.OrderBy(p => p.RemarkReplyID).Take(3);
            TieziViewModel tiz = new TieziViewModel()
            {
                Getpinglun = ire.Getcommentsbyid(id),
                Gethuifu = remarkreply,
                Gettiezi = ir.FindRemarksByID(id)

            };
            return View(tiz);
      }
    }
}
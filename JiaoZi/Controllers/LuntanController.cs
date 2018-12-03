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
        //Models.TieziViewModel tieziviewmodel = new Models.TieziViewModel();

        // GET: Luntan
        public ActionResult Index()
        {
            IRemark_User_Comments_Reply ir = new RRemark_User_Comments_Reply();
            if (ir.Getsall() != null)
                return View(ir.Getsall());
            //IRemarksbytime ir1 = new RRemarksbytime();
            

            return View();
        }
        public ActionResult Index2(int id)
        {
            //IRemarksbytime ir1 = new RRemarksbytime();
            //if (ir1.Contentbytime() != null)
            //    return View(ir1.Contentbytime());
            //jiaoziEntities db = new jiaoziEntities();
            //var list=db.Remarks.Where(b=>b.RemarkContent)
            IRemarks ir = new RRemarks();
            //if (ir.FindRemarksByID(id) != null)
                return View(ir.FindRemarksByID(id));
            //else if (ir.FindRemarksByID(id) != null)
            //    return View(ir.FindRemarksByID(id));
            //else if (ir.FindRemarksByID(1) != null)
            //    return View(ir.FindRemarksByID(1));
            //else if (ir.FindRemarksByID(4) != null)
            //    return View(ir.FindRemarksByID(4));
            //return View();

        }


    }
}
using JiaoZi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JiaoZi.Controllers
{
    public class MallController : Controller
    {
        jiaoziEntities db = new jiaoziEntities();
        IMall imall;
        public MallController()
        {
            imall = new Mall();
        }
        // GET: Mall
        public ActionResult Index()
        {

            Models.Mallview viewModel = new Models.Mallview
            {
                Price = imall.GetBooksByPrice(),
                Chinese = imall.GetBooksBycategory("语文"),
                Math = imall.GetBooksBycategory("数学"),
                English = imall.GetBooksBycategory("英语"),
                Political = imall.GetBooksBycategory("政治"),
                Synthesize = imall.GetBooksBycategory("综合"),
                History = imall.GetBooksBycategory("历史"),
                Chemistry = imall.GetBooksBycategory("化学"),
                Interview = imall.GetBooksBycategory("面试"),
                Art = imall.GetBooksBycategory("美术"),
                Psychic = imall.GetBooksBycategory("心理学"),
                Pedagogy = imall.GetBooksBycategory("教育学"),
                Hotsale = imall.GetBooksByAmount()
            };

            return View(viewModel);
        }
        

        [HttpPost]
        public ActionResult Sear()
        {
            string search = Request.Form["search"].ToString();
            var Searchbooks = imall.Search(search);
            if(Searchbooks!=null)
            {
                return PartialView(Searchbooks);
            }
            else                                    //BUG
                return Content("<script>alert('未找到相关书籍');history.go(-1);</script>");
        }

        //查询图书  替换id 分布视图
        //[HttpPost]
        //public ActionResult Sear (string search)
        //{
        //    var Search = imall.Search(search);
        //    return View(search);
        //}
    }
}
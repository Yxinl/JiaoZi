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
            //var price = imall.GetBooksByPrice();
            //var english = imall.GetBooksBycategory("英语");
            //var mate = imall.GetBooksBycategory("心理学");
            //var putonghua = imall.GetBooksBycategory("普通话");
            //var books = imall.GetBooks();
            Models.Mallview viewModel = new Models.Mallview
            {
                 price = imall.GetBooksByPrice(),
                 Chinese = imall.GetBooksBycategory("语文"),
                 Math= imall.GetBooksBycategory("数学"),
                 English= imall.GetBooksBycategory("英语"),
                 Political= imall.GetBooksBycategory("政治"),
                 Synthesize = imall.GetBooksBycategory("综合"),
                 History = imall.GetBooksBycategory("历史"),
                 Chemistry= imall.GetBooksBycategory("化学"),
                 Interview = imall.GetBooksBycategory("面试"),
                 Art= imall.GetBooksBycategory("美术"),
                 Psychic = imall.GetBooksBycategory("心理学"),
                 Pedagogy= imall.GetBooksBycategory("教育学"),
            };

            return View(viewModel);
        }
    }
}
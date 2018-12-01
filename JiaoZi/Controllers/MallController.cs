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
                 Price = imall.GetBooksByPrice(),
                 English = imall.GetBooksBycategory("英语"),
                 Psychological= imall.GetBooksBycategory("心理学"),
                 Chinese= imall.GetBooksBycategory("语文"),
                 Math = imall.GetBooksBycategory("数学"),
                 Synthesize= imall.GetBooksBycategory("综合"),
                 Political = imall.GetBooksBycategory("政治"),
                 Chemistry= imall.GetBooksBycategory("化学"),
                 Art = imall.GetBooksBycategory("美术"),
                 Interview = imall.GetBooksBycategory("面试"),
                 Pedagogy = imall.GetBooksBycategory("教育学"),
                 History= imall.GetBooksBycategory("历史"),

            };

            return View(viewModel);
        }
    }
}
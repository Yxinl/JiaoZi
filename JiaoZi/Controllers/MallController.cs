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
                 English = imall.GetBooksBycategory("英语"),
                 Mate = imall.GetBooksBycategory("心理学"),
                 Putonghua = imall.GetBooksBycategory("普通话"),
             };

            return View(viewModel);
        }
    }
}
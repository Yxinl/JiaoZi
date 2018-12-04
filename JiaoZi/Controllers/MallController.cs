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


        //主页显示
        public ActionResult Index()
        {

            Models.Mallview viewModel = new Models.Mallview
            {
        
                Hotsale = imall.GetBooksByAmount(),
                Category = imall.Category(),
                CateBooks = imall.GetBooksByCategory(1),
                CateBooks1 = imall.GetBooksByCategory(2),
                CateBooks2= imall.GetBooksByCategory(3),
                CateBooks3 = imall.GetBooksByCategory(4),
                CateBooks4 = imall.GetBooksByCategory(5)
            };
            return View(viewModel);
        }
        
        //搜索图书
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
                return HttpNotFound();
        }



        //根据ID查某本图书
        public ActionResult BooksDetails(int id)
        {
            var details = imall.GetBooksById(id);
            ViewData["image"] = details.BookImage;
            ViewData["details"] = details;
            return View(details);
        }
    }
}
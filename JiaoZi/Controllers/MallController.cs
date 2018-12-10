using JiaoZi.Models;
using PagedList;
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
            #region
            Models.Mallview viewModel = new Models.Mallview

            {

                Hotsale = imall.GetBooksByAmount(),
                Category = imall.Category(),
                CateBooks = imall.GetBooksByCategory(1),
                CateBooks1 = imall.GetBooksByCategory(2),
                CateBooks2 = imall.GetBooksByCategory(3),
                CateBooks3 = imall.GetBooksByCategory(4),
                CateBooks4 = imall.GetBooksByCategory(5),
                NewBooks = imall.GetBooksByTime(),
                Onsale=imall.GetBooksByPrice(),
            };
            #endregion
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
            else                                 
                return HttpNotFound();
        }


        //获取导航条
        public ActionResult Nav()
        {
            var CatagoryName = imall.Category();

            return PartialView(CatagoryName);
        }

        //根据ID查某本图书
        public ActionResult BooksDetails(int id)
        {
            CommentReply a = new CommentReply(id);
            return View(a);
        }

        //分页显示某类图书
        public ActionResult  BooksType(string CategoryName,string currentFilter, int ? page)
        {
            var books = imall.GetBooks();
            if (CategoryName != null)
            {
                page = 1;
            }
            else
            {
                CategoryName = currentFilter;
            }
            ViewBag.CurrentFilter = CategoryName;
            if (!string.IsNullOrEmpty(CategoryName))
            {
                books = books.Where(x => x.Category == CategoryName);

            }
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return PartialView(books.ToPagedList(pageNumber, pageSize));
        }

        //显示图书
        public ActionResult BooksShow(string CategoryName)
        {
            var books = imall.GetBooks().Where(x => x.Category == CategoryName);
            return View(books);
        }

        
    }
}
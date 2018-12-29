using JiaoZi.Attributes;
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


        //获取数目
        public ActionResult Num(int? UserID)
        {
            UserID = Convert.ToInt32(Session["User_id"]);
            var OrderID = db.Orders.Where(o => o.UserID == UserID);
            int sum = 0;
            if (UserID != null)
            {
                foreach (var i in OrderID)
                {
                    var orderDetails = db.OrderDetails.Where(o=>o.OrderDetailsID==i.OrderDetailsID);
                    foreach (var q in orderDetails)
                    {
                        sum += Convert.ToInt32(q.Count);
                    }
                }
                return Content(sum.ToString());
            }
            else
            return Content(0.ToString());
        }

        //根据ID查某本图书
        public ActionResult BooksDetails(int id)
        {
            Session["BookID"] = id;
            BooksDetails a = new BooksDetails(id);
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

        public ActionResult Comment(int BookID)
        {
            BookID = Convert.ToInt32(Session["BookID"]);
            var comment = db.BookComment.Where(x => x.BookID == BookID);
            return PartialView(comment);
        }


        //需重写
        [HttpPost]
        [Login]
        public ActionResult Comment(BookComment comment)
        {
            #region
            int BookID = Convert.ToInt32(Session["BookID"]);
            BooksDetails a = new BooksDetails(BookID);
            int UserID;
            var UserComment = a.Bc;
            ViewBag.Comment = UserComment;
            if (Session["User_id"] != null)
            {
                UserID = Convert.ToInt32(Session["User_id"]);
                string textarea = Request["Comment_Content"];
                if (ModelState.IsValid)
                {
                    if (textarea != "")
                    {
                        comment.UserID = UserID;
                        comment.BookID = BookID;
                        comment.Comment_Content = textarea;
                        comment.Comment_Time = System.DateTime.Now;
                        imall.AddComment(comment);
                        UserComment = a.Bc;
                        ViewBag.Comment = UserComment;
                        Session["tishi"] = "评论成功";
                        return PartialView(ViewBag.Comment as IEnumerable<BooksDetails>);
                    }
                    else
                    {
                        Session["tishi"] = "评论不能为空";
                        return PartialView(ViewBag.Comment as IEnumerable<BooksDetails>);
                    }

                }
                return PartialView(ViewBag.Comment as IEnumerable<BooksDetails>);

            }
            else
            {
                return Content("<script>alert('请先登录');;window.location.href='../Default/RegisteLogin';</script>");
            }
            #endregion
            //var BookID=Session[""]
        }

        //回复    
        //public ActionResult Reply(int? BookID)
        //{
        //    BookID = Convert.ToInt32(Session["BookID"]);
        //    var BookCommentID = db.BookComment.Where(o => o.BookID == BookID).FirstOrDefault().BookCommentID;
        //    var ReplyComment = db.BookReply.Where(o => o.BookCommentID == BookCommentID).ToList();
        //    ViewBag.ReplyComment = ReplyComment;
        //    return PartialView(ReplyComment);
        //}


        //显示订单
        [Login]
        public ActionResult Order(int? id)
        {
            var orders = imall.Orders(id);
            return View(orders);
        }


        //显示用户所选商品
        [Login]
        public ActionResult OrderDetails(int? id)
        {
            //id = Convert.ToInt32(Session["User_id"]);
            var Ordersdetails = imall.OrderDetails(id);
            return View(Ordersdetails);
        }



        //加入购物车
        public ActionResult TakeIn()
        {
            return View();
        }
    }
}
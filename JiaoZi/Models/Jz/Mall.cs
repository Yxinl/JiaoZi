using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class Mall:IMall
    {
        jiaoziEntities db = new jiaoziEntities();
        //获取全部图书
       public IEnumerable<Books> GetBooks()
        {
            var books = db.Books.ToList();
            return books;
        }
        //获得单独一本书的详情
        public Books GetBooksById(int? id)
        {
            var books = db.Books.Find(id);
            return books;
        }
        //根据书名或者作者名进行搜索
        public IEnumerable<Books> Search(string search)
        {
            var sear = from p in db.Books
                       where p.BookName.Contains(search) || p.BookAuthor.Contains(search)
                       select p;
            return sear.ToList();
        }
        //升序排列 找出数量最少的三本 热销榜
        public IEnumerable<Books> GetBooksByAmount()
        {
            var AmountBooks = (from p in db.Books
                               orderby p.Amount ascending
                               select p).Take(3);
            return AmountBooks;
                           
        }
        //获取图书的种类
        public IEnumerable<Category> Category()
        {
            var category = (from p in db.Category                         
                           select p).ToList();
            return category;
        }

        //根据id查每类的图书
       public IEnumerable<Books> GetBooksByCategory(int id)
        {
            var categorybooks = from p in db.Books
                                where p.CategoryId == id
                                select p;
            return categorybooks;
        }


        //根据时间查书
        public IEnumerable<Books> GetBooksByTime()
        {
            var Books = (from p in db.Books
                         orderby p.IssueTime descending
                         select p).Take(4);
            return Books;
        }

        //根据价格查书
        public IEnumerable<Books> GetBooksByPrice()
        {
            var books = from p in db.Books
                         orderby p.Price ascending
                         select p;
            return books.ToList();
        }

       
        //添加图书
        public void AddBooks(Books books)
        {
            db.Books.Add(books);
            db.SaveChanges();
        }

        public void AddComment(BookComment comment)
        {
            db.BookComment.Add(comment);
            db.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaoZi.Models
{
    interface IMall
    {
        IEnumerable<Books> GetBooks();
        Books GetBooksById(int? id);
        IEnumerable<Books> Search(string search);
        IEnumerable<Books> GetBooksByAmount();
        IEnumerable<Category> Category();
        IEnumerable<Books> GetBooksByPrice();
        IEnumerable<Books> GetBooksByTime();
        void AddBooks(Books books);
        IEnumerable<Books> GetBooksByCategory(int id);
        void AddComment(BookComment comment);
        IEnumerable<Orders> Orders(int? id);
        IEnumerable<OrderDetails> OrderDetails(int id);
    }
}

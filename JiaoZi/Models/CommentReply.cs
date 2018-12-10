using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class CommentReply
    {
        public IEnumerable<BookComment> Bc{ get;set;}
        public Books b { get; set; }
        public CommentReply(int id)
        {
            jiaoziEntities db = new jiaoziEntities();
            Bc = db.BookComment.Where(o => o.BookID == id);
            b = db.Books.Where(b => b.BookID == id).FirstOrDefault();
        }
        
    }
}
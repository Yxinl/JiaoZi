using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaoZi.Models
{
    public class Mallview
    {
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<Books> CateBooks { get; set; }
        public IEnumerable<Books> CateBooks1 { get; set; }
        public IEnumerable<Books> CateBooks2 { get; set; }
        public IEnumerable<Books> CateBooks3 { get; set; }
        public IEnumerable<Books> CateBooks4 { get; set; }
        public IEnumerable<Books> Search { get; set; }
        public IEnumerable<Books> Hotsale { get; set; }
        public IEnumerable<Books> Onsale { get; set; }
        //public Mv Mvs { get; set; }
        //public Booksview Booksview { get; set; }
    }


    //public class Mv
    //{
    //    public IEnumerable<Category> Category { get; set; }
    //    public IEnumerable<Books> CateBooks { get; set; }
    //    public IEnumerable<Books> CateBooks1 { get; set; }
    //    public IEnumerable<Books> CateBooks2 { get; set; }
    //    public IEnumerable<Books> CateBooks3 { get; set; }
    //    public IEnumerable<Books> CateBooks4 { get; set; }
    //    public IEnumerable<Books> Search { get; set; }
    //    public IEnumerable<Books> Hotsale { get; set; }
    //    public IEnumerable<Books> Onsale { get; set; }

    //}


    //public class Booksview
    //{
    //    public Books Books { get; set; }
    //}
}
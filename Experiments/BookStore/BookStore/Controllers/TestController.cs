using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class TestController : Controller
    {
        BookStoreEntities context = new BookStoreEntities();
        
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }


        // GET: /test/books
        public ActionResult Books()
        {
            // context.Configuration.ProxyCreationEnabled = false;
            // var books = context.Books.ToList();

            var books = from b in context.Books
                        select new { b.BookId, b.Title, b.BookCoverUrl, b.CategoryId, b.Price, b.Authors };

            //var books = context.Books.SelectMany()

            return Json(books.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}
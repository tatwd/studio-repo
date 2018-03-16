using BookStore.Models;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class StoreController : Controller
    {
        BookStoreEntities context = new BookStoreEntities();

        // GET: Store
        public ActionResult Index()
        {
            var books = context.Books;

            // return Json(books, JsonRequestBehavior.AllowGet);
            return View(books);
        }

        public ActionResult Order(int? id)
        {

            var book = context.Books
                .Where(b => b.BookId == id)
                .FirstOrDefault();

            // add book info to `ViewData`
            ViewBag.BookId = book.BookId;
            ViewBag.Authors = book.Authors;
            ViewBag.BookTitle = book.Title;
            ViewBag.Price = book.Price;
            ViewBag.BookCoverUrl = book.BookCoverUrl;

            return View();
        }

        [HttpPost]
        public ActionResult Order(int BookId, int BookCount, string Address)
        {
            var order = new Orders
            {
                 
            };

            //// add order to db
            //context.Orders.Add(order);

            //// save to db
            //context.SaveChanges();

            //return View();
            return Json(order);
        }

        public ActionResult Details()
        {
            return View();
        }
    }
}
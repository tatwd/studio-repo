using BookStore.Models;
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

        public ActionResult Order()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }
    }
}
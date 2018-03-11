using MvcSignPage.Models;
using System.Web.Mvc;

namespace MvcSignPage.Controllers
{
    public class UserController : Controller
    {
        BmdDbContext db = new BmdDbContext();

        // GET: User/SignIn
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(User user)
        {
            // User hasUser = db.Users.;

            return Json(hasUser);
        }

        // GET: User/SignUp
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("SignIn");
            }

            return Json(user);
        }
    }
}
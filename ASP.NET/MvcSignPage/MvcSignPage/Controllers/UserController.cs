using MvcSignPage.Models;
using System.Web.Mvc;
using System.Linq;

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
        // [ValidateAntiForgeryToken]
        public ActionResult SignIn(User user)
        {
            //var users = from u in db.Users
            //             select u;

            //users = users.Where(
            //    u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password));

            //ViewBag.IsSignIn = users.ToArray().Length != 0 ? true : false;

            //return View();
            return Json(user);
        }

        // GET: User/SignUp
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        // [Bind(Include = "Usename,Email,Telephone,Password")]
        public ActionResult SignUp(User user)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Users.Add(user);
            //    db.SaveChanges();
            //    return RedirectToAction("SignIn");
            //}

            //ViewBag.IsSignUp = false;

            //return View();

            if (ModelState.IsValid)
                return Json(user);

            return View();
        }
    }
}
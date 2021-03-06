﻿using MvcSignPage.Models;
using MvcSignPage.ViewModels;
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
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInViewModel vmuser)
        {
            if (!ModelState.IsValid)
                return View();

            var user = db.Users
                .Where(u => u.Username.Equals(vmuser.Username) && u.Password.Equals(vmuser.Password))
                .FirstOrDefault();

            //var users = from u in db.Users
            //            select u;

            //users = users.Where(
            //    u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password));

            ViewBag.IsSignIn = user != null;

            // return View();
            return Json(user);
        }

        // GET: User/SignUp
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Bind(Include = "Usename,Email,Telephone,Password")]
        public ActionResult SignUp(SignUpViewModel user)
        {
            if (ModelState.IsValid)
            {
                User iuser = new User
                {
                    Username = user.Username,
                    Email = user.Email,
                    Password = user.Password,
                    Telephone = user.Telephone
                };

                db.Users.Add(iuser);
                db.SaveChanges();

                return RedirectToAction("SignIn");
            }

            ViewBag.IsSignUp = false;

            return View();

            //if (ModelState.IsValid)
            //    return Json(user);
            //return View();
        }
    }
}
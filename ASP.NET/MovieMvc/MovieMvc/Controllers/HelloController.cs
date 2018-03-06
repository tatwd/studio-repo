using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieMvc.Models;

namespace MovieMvc.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Index()
        {


            return View();
        }

        // 查询
        public ActionResult Query(string name = "movie name", int id = 1000)
        {
            //ViewBag.Name = name;
            //ViewBag.Id = id;

            var movie = new Movie { Id = id, Name = name };

            return View(movie);
        }
    }
}
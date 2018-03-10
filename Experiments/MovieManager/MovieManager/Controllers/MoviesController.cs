using MovieManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MovieManager.Controllers
{
    public class MoviesController : Controller
    {
        private MovieDbContext db = new MovieDbContext();

        // init a collection of movies
        IList<Movie> movies = new List<Movie>
        {
            new Movie
            {
                Id = "001",
                Name = "The Shawshank Redemption",
                Director = "Frank A. Darabont",
                ReleaseDate = DateTime.Parse("1994-09-10"),
                Rating ="9.6"
            },
            new Movie
            {
                Id = "002",
                Name = "Farewell My Concubine",
                Director = "Kaige Chen",
                ReleaseDate = DateTime.Parse("1993-01-01"),
                Rating = "9.5"
            },
        };

        // GET: Home
        public ActionResult Index()
        {
            //db.Movies.AddRange(movies);
            //db.SaveChanges();

            return View(db.Movies.ToList());
        }

        // view info of a movie
        // and add management stuff - delete or edit
        public ActionResult Info(string id)
        {
            Movie movie = new Movie();

            movie = db.Movies.Find(id);

            return View(movie);
        }

        // edit a movie info
        //public ActionResult Edit()
        //{
        //    return View();
        //}

        public ActionResult Edit(string id)
        {
            Movie movie = new Movie();

            movie = db.Movies.Find(id);

            return View(movie);
        }

        // GET: Movies/New
        public ActionResult New()
        {
            return View();
        }

        // add a new movie item
        [HttpPost]
        public ActionResult New(Movie movie)
        {
            if (movie.Id != null)
                return RedirectToAction("Index");

            // TODO: add a new movie to db

            return View(movie);
        }

        public ActionResult Delete(FormCollection fcNotUsed, string id)
        {
            Movie movie = db.Movies.Find(id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            db.Movies.Remove(movie);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // test stuff
        [HttpGet]
        public ActionResult JsonApi(string id)
        {
            var movie = db.Movies.Find(id);

            return Json(movie, JsonRequestBehavior.AllowGet);
            // return Json(movie);
        }
    }
}
using MVCMovieCustWithAuth.Models;
using MVCMovieCustWithAuth.View_Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMovieCustWithAuth.Controllers
{

    public class MoviesController : Controller
    {
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies

        public ActionResult Index()
        {
            var mov = _context.Movies.Include(c => c.Genre).ToList();
            return View(mov);
        }
        public ActionResult Details(int id)
        {
            var singleMovie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (singleMovie == null)
            {
                return HttpNotFound();
            }
            return View(singleMovie);
        }

        [HttpGet]

        public ActionResult New()
        {
            var genre = _context.Genres.ToList();

            var viewModel = new NewMovieViewModel
            {
                GenreType = genre
            };
            return View(viewModel);
        }

        //[HttpPost]

        //public ActionResult Create(Movie movie)//Model binding

        //{

        //    _context.Movies.Add(movie);

        //    _context.SaveChanges();

        //    return RedirectToAction("Index", "Movies");

        //}

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var MovieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                MovieInDb.Name = movie.Name;

                MovieInDb.Genre = movie.Genre;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");//Back to customer controller page
        }

        public ActionResult Edit(int id)
        {
            var updateCast = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (updateCast == null)
            {
                return HttpNotFound();
            }
            var vm = new NewMovieViewModel
            {
                Movie = updateCast,
                GenreType = _context.Genres.ToList()
            };
            return View("New", vm);
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
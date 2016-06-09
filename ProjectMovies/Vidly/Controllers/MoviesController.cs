using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/ListMovies
        public ActionResult ListMovies()
        {
            var movies = new List<Movie>
            {
                new Movie { Name = "Gladiador", Id = 0},
                new Movie { Name = "Taken", Id = 1 },
                new Movie { Name = "Harry Potter", Id = 2 },
            };

            var viewModel = new ListMoviesViewModel 
            {
                Movies = movies
            };


           // return Content("Conteudo é: " + viewModel.Movies[1].Id);
            return View(viewModel);
            //return Content("Hello World");
            //return HttpNotFound();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
       
        }

        [Route("movies/moviedetails/{movie}")]
        public ActionResult MovieDetails(string movie)
        {
            ViewBag.Movie = movie;

            return View();
        }


        public ActionResult Edit(int id)
        {
            return Content("id = "+ id);
        }

        // movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        // regex não funcionou
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2})}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + " / " + month);
        }
    }
}
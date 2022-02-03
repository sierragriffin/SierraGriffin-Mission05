//Controller

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission04Assignment.Models;

namespace Mission04Assignment.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _movieContext { get; set; }

        //Constructor
        public HomeController(MovieContext x)
        {
            _movieContext = x;
        }

        //Index View
        public IActionResult Index()
        {
            return View();
        }

        //Podcast Page View
        public IActionResult MyPodcasts()
        {
            return View();
        }

        //Add Movie View
        [HttpGet]
        public IActionResult MovieForm()
        { 

            ViewBag.Categories = _movieContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(AddMovieResponse amr)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(amr);
                _movieContext.SaveChanges();

                return View("Confirmation", amr);
            }
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();

                return View(amr);
            }
        }

        //MovieList View
        [HttpGet]
        public IActionResult MovieList()
        {
            var movies = _movieContext.Responses
                .Include(y => y.Category)
                .OrderBy(y => y.Year)
                .ToList();

            return View(movies);
        }

        //Edit View
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            var movie = _movieContext.Responses.Single(y => y.MovieId == movieid);

            return View("MovieForm", movie);
        }

        [HttpPost]
        public IActionResult Edit(AddMovieResponse movieresponse)
        {
            _movieContext.Update(movieresponse);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        //Delete View
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = _movieContext.Responses.Single(y => y.MovieId == movieid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(AddMovieResponse movieresponse) 
        {
            _movieContext.Responses.Remove(movieresponse);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}

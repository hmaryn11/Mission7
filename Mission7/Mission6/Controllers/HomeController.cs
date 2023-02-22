using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private MovieEntryContext _movieContext { get; set; } //define the scope to be any of the methods

        //contructor
        public HomeController(MovieEntryContext someName)
        {
            _movieContext = someName; 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovie()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            return View(new EntryResponse());
        }

        [HttpPost]
        public IActionResult EnterMovie(EntryResponse response)
        {
            if (ModelState.IsValid)//the responses must be pass the requirements to be added to and saved to the system
            {
                _movieContext.Add(response); //adds info from response to the database
                _movieContext.SaveChanges(); //saves changes to db
                return View("ResponseToResponse", response);
            }
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();

                return View();
            }
        }
        public IActionResult MovieTable()
        {
            var entries = _movieContext.Responses
                .Include(x => x.Category)
                .OrderBy(y => y.movieTitle)
                .ToList();

            return View(entries);
        }
        [HttpGet]
        public IActionResult Edit(int appid)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            var entry = _movieContext.Responses.Single(x => x.MovieId == appid);

            return View("EnterMovie", entry);
        }

        [HttpPost]
        public IActionResult Edit(EntryResponse newEdit)
        {
            _movieContext.Update(newEdit);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieTable");
        }

        //private IActionResult View(Func<IActionResult> movieTable)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpGet]
        public IActionResult Delete(int appid)
        {
            var entry = _movieContext.Responses.Single(x => x.MovieId == appid);
            return View("Deleted", entry);
        }

        [HttpPost]
        public IActionResult Delete(EntryResponse er)
        {
            _movieContext.Responses.Remove(er);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieTable");
        }

    }
}

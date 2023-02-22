﻿using Microsoft.AspNetCore.Mvc;
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
            return View();
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
                return View();
            }
        }
    }
}

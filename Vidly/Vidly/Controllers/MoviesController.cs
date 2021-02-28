﻿using System;
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
        List<Movie> movies = new List<Movie>()
        {
            new Movie()
            {
                Name = "Shrek"
            },
            new Movie()
            {
                Name = "Wall-e"
            }
        };
        public ActionResult Index()
        {
            var movieList = new MovieListViewModel();
            movieList.Movies = movies;

            return View(movieList);
        }
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1 "},
                new Customer { Name = "Customer 2 "}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //every view has a viewData dictionary
            //ViewData["Movie"] = movie;

            
            //return View(movie);

            //return Content("Hello world!"); //returning Content type action result

            //return HttpNotFound(); //returning http not found action result

            //return new EmptyResult(); //returning an empty result

            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" }); //redirects to home page (index) with params page and sortBy


        }

        //the framework will automatically map the parameter in the URL to the field "id"
        //because of this in the RouteConfig.cs => url: "{controller}/{action}/{id}"
        //if we rename it to movieId and send movie/edit/1, we get a runtime error
        //to resolve that, we might need to send the url move/edit?movieId=1
        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        //adding optional params to controller methods
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("page index = {0} and sortBy = {1}", pageIndex, sortBy));
               
        //}

        //we can also add constrains to a route like this:
        //Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)") -- month should be only 2 digits and between 1 and 12
        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }        
    }
}
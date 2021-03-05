using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DataLayer;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private AppDbContext _context;

        public MoviesController()
        {
            _context = new AppDbContext();
        }

        //GET api/movies
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            var movies = _context.Movies.ToList();

            return Ok(movies);
        }

        //GET api/Movies/id
        [HttpGet]
        public IHttpActionResult GetMovies(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        //POST api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Ok(movie);
        }

        //update movies
        [HttpPut]
        public IHttpActionResult UpdateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = _context.Movies.SingleOrDefault(x => x.Id == movie.Id);
            if(movieInDb == null)
            {
                return NotFound();
            }

            movieInDb.Name = movie.Name;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.GenreId = movie.GenreId;
            movieInDb.DateAdded = movie.DateAdded;
            _context.SaveChanges();

            return Ok(movie);
        }

        //delete movies
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(x => x.Id == id);
            if(movieInDb == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}

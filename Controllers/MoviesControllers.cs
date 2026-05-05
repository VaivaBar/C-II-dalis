using App.Data;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;


namespace App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext context;
        public MoviesController(AppDbContext context)
        {
            this.context = context;
        }

    [HttpGet]
    public IActionResult GetAllMovies()
    {
        var movies = context.Movies.ToList();
        return Ok(movies);
    }

    [HttpPost]

    public IActionResult AddMovies (AddMovies moviesData)
    {
        var moviesEntity = new Movies
        {
            Id = moviesData.Id,
            Title = moviesData.Title,
            Year = moviesData.Year,
            Rating = moviesData.Rating,
            GenreId = moviesData.GenreId,
            DirectorId = moviesData.DirectorId,
        };

        context.Movies.Add(moviesEntity);
        context.SaveChanges();
        return Ok(moviesEntity);
    }

    [HttpDelete]

    [Route("{id:int}")]
    public IActionResult DeleteMovie(int id)
    {
        var movie = context.Movies.Find(id);
        if (movie == null)
        {
            return NotFound("Student not found.");
        }

        context.Movies.Remove(movie);
        context.SaveChanges();

        return Ok("Movie was deleted.");
    }


    [HttpPut]
    [Route("{id:int}")]

    public IActionResult UpdateMovie(int id, AddMovies updateMovieData)
    {
        var movie = context.Movies.Find(id);

        if (movie == null)
        {
            return NotFound();
        }

        Id = moviesData.Id;
        Title = moviesData.Title;
        Year = moviesData.Year;
        Rating = moviesData.Rating;
        GenreId = moviesData.GenreId;
        DirectorId = moviesData.DirectorId;

        context.SaveChanges();

        return Ok(movie);
    }
}

}
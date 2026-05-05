using App.Data;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;


namespace App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class GenresController : ControllerBase
    {
        private readonly AppDbContext context;
        public GenresController(AppDbContext context)
        {
            this.context = context;
        }

    [HttpGet]
    public IActionResult GetAllGenres()
    {
        var genres = context.Genres.ToList();
        return Ok(genres);
    }

    [HttpPost]

    public IActionResult AddGenres (AddGenres genresData)
    {
        var genresEntity = new Genres
        {
            Id = genresEntity.Id,
            Name = genresEntity.Name,
        };

        context.Genres.Add(genresEntity);
        context.SaveChanges();
        return Ok(genresEntity);
    }

    [HttpDelete]

    [Route("{id:int}")]
    public IActionResult DeletGenres(int id)
    {
        var genre = context.Genres.Find(id);
        if (genre == null)
        {
            return NotFound("Genres not found.");
        }

        context.Genres.Remove(genres);
        context.SaveChanges();

        return Ok("Genre was deleted.");
    }


    [HttpPut]
    [Route("{id:int}")]

    public IActionResult UpdateGenre(int id, AddGenres updateGenreData)
    {
        var genre = context.Genres.Find(id);

        if (genre == null)
        {
            return NotFound();
        }

           Id = genresEntity.Id;
           Name = genresEntity.Name;

        context.SaveChanges();

        return Ok(genre);
    }
}

}
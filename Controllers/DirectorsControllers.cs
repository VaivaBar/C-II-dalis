using App.Data;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DirectorsController : ControllerBase
    {
        private readonly AppDbContext context;
        public DirectorsController(AppDbContext context)
        {
            this.context = context;
        }

    [HttpGet]
    public IActionResult GetAllDirectors()
    {
        var directors = context.Directors.ToList();
        return Ok(directors);
    }

    [HttpPost]

    public IActionResult AddDirectors (AddDirectors directorsData)
    {
        var directorsEntity = new Directors
        {
            Id = directorsData.Id,
            FullName = directorsData.FullName,
            Country = directorsData.Country,
        };

        context.Directors.Add(directorsEntity);
        context.SaveChanges();
        return Ok(directorsEntity);
    }

    [HttpDelete]

    [Route("{id:int}")]
    public IActionResult DeletDirectors(int id)
    {
        var director = context.Directors.Find(id);
        if (director == null)
        {
            return NotFound("Director not found.");
        }

        context.Directors.Remove(director);
        context.SaveChanges();

        return Ok("Director was deleted.");
    }


    [HttpPut]
    [Route("{id:int}")]

    public IActionResult UpdateDirector(int id, AddDirectors updateDirectorData)
    {
        var director = context.Directors.Find(id);

        if (director == null)
        {
            return NotFound();
        }

            Id = directorsData.Id;
            FullName = directorsData.FullName;
            Country = directorsData.Country;

        context.SaveChanges();

        return Ok(director);
    }
}

}
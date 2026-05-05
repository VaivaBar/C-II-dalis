namespace App.Models;

public class Movies
{
    public int Id { get; set ; }
    public string Title { get; set; }
    public int Year { get; set; }
    public decimal Rating { get; set; }
    public int GenreId { get; set; }
    public int DirectorId { get; set; }

}
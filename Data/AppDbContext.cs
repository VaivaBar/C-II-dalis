using Microsoft.EntityFrameworkCore; 
using App.Models; 

namespace App.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 

    }
    public DbSet<Movies> Movies  { get; set; } 
    public DbSet<Genres> Genres  { get; set; } 
    public DbSet<Directors> Directors  { get; set; } 
}
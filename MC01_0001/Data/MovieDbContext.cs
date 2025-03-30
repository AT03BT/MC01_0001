// Data/MovieDbContext.cs
// Version: 1.0.0
// (c) 2024, Minh Tri Tran, with assistance from Google's Gemini - Licensed under CC BY 4.0
// https://creativecommons.org/licenses/by/4.0/


using Microsoft.EntityFrameworkCore;
using MC01_0001.Models;

namespace MC01_0001.Data
{

    public class MovieCatalogueDbContext : DbContext
    {
        public MovieCatalogueDbContext(DbContextOptions<MovieCatalogueDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
    }

}
﻿/*
    Data/MovieDbContext.cs
    Version: 1.0.0
    (c) 2024, Minh Tri Tran, with assistance from Google's Gemini - Licensed under CC BY 4.0
    https://creativecommons.org/licenses/by/4.0/

    This work builds upon concepts and examples from:
    "Get started with ASP.NET Core MVC | Microsoft Learn"
    https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-8.0&tabs=visual-studio
*/

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
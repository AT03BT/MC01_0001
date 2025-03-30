// Models/Movies.cs
// Version: 1.0.0
// (c) 2024, Minh Tri Tran, with assistance from Google's Gemini - Licensed under CC BY 4.0
// https://creativecommons.org/licenses/by/4.0/

using System.ComponentModel.DataAnnotations;

namespace MC01_0001.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
}

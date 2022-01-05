using System;

namespace Net5.AspNetCore.Client.MVC.Models
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}

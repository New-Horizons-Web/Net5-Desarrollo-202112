using Net5.AspNetCore.Client.MVC.Models;
using System;
using System.Collections.Generic;

namespace Net5.AspNetCore.Client.MVC.Services
{
    public class MovieService
    {
        private List<MovieViewModel> _movies;

        public MovieService()
        {
            InitData();
        }

        public List<MovieViewModel> ListMovies()
        {
            return _movies;
        }

        private void InitData()
        {
            _movies = new List<MovieViewModel>();

            _movies.Add(new MovieViewModel
            {
                Id = Guid.NewGuid(),
                Title = "Spider-Man: No Way Home",
                Genre = "Ciencia ficción",
                Price = (decimal)150.45,
                ReleaseDate = DateTime.Now
            });

            _movies.Add(new MovieViewModel
            {
                Id = Guid.NewGuid(),
                Title = "Sing 2",
                Genre = "Animación",
                Price = (decimal)115.20,
                ReleaseDate = DateTime.Now
            });


            _movies.Add(new MovieViewModel
            {
                Id = Guid.NewGuid(),
                Title = "The Matrix Resurrections",
                Genre = "Ciencia ficción",
                Price = (decimal)201.78,
                ReleaseDate = DateTime.Now
            });


            _movies.Add(new MovieViewModel
            {
                Id = Guid.NewGuid(),
                Title = "Resident Evil: Welcome to Raccoon City",
                Genre = "Acción",
                Price = (decimal)135.63,
                ReleaseDate = DateTime.Now
            });


            _movies.Add(new MovieViewModel
            {
                Id = Guid.NewGuid(),
                Title = "Venom: Carnage Liberado",
                Genre = "Ciencia ficción",
                Price = (decimal)148.96,
                ReleaseDate = DateTime.Now
            });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Net5.AspNetCore.Client.MVC.Services;
using System.Threading.Tasks;

namespace Net5.AspNetCore.Client.MVC.Components
{
    [ViewComponent(Name ="Movies")]
    public class MoviesComponent:ViewComponent
    {
        private readonly MovieService _movieService;
        public MoviesComponent(MovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Index",_movieService.ListMovies());
        }
    }
}

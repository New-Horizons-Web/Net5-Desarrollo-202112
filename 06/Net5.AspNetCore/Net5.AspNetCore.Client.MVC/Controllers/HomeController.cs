using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Net5.AspNetCore.Client.MVC.Models;
using Net5.AspNetCore.Client.MVC.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNetCore.Client.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovieService _movieService;

        public HomeController(ILogger<HomeController> logger,MovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel()
            {
                Movies = _movieService.ListMovies(),
                PageTitle = "List Movies",
                UserName = "Erick"
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

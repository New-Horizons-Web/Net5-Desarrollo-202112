using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Net.Fundamentals.DI.MVC.Application;
using Net.Fundamentals.DI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Net.Fundamentals.DI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IGuidGenerator _guidGenerator;
        private readonly IGuidTransient _guidTransient;
        private readonly IGuidScoped _guidScoped;
        private readonly IGuidSingleton _guidSingleton;

        public HomeController(
            ILogger<HomeController> logger,
            IGuidGenerator guidGenerator,
            IGuidTransient guidTransient,
            IGuidScoped guidScoped,
            IGuidSingleton guidSingleton
        )
        {
            _logger = logger;

            _guidGenerator = guidGenerator;

            _guidTransient = guidTransient;
            _guidScoped = guidScoped;
            _guidSingleton = guidSingleton;
        }

        public IActionResult Index()
        {            
            HomeViewModel model = new HomeViewModel()
            {
                GuidTransientController = _guidTransient.GetGuid(),
                GuidTransientGenerator = _guidGenerator.GetGuidTransient(),

                GuidScopedController = _guidScoped.GetGuid(),
                GuidScopedGenerator = _guidGenerator.GetGuidScoped(),
                
                GuidSingletonController = _guidSingleton.GetGuid(),
                GuidSingletonGenerator = _guidGenerator.GetGuidSingleton()
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

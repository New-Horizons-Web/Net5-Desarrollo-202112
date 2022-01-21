using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Net5.Security.Cross_Site_Scripting.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.Security.Cross_Site_Scripting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult JavascriptAttack(string userId)
        {
            Customer customer = new Customer { UserId = userId };
            return View(customer);
        }
        [HttpPost]
        public IActionResult JavascriptAttack(Customer model)
        {
            return RedirectToAction("JavascriptAttack", new { userId = model.UserId });
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

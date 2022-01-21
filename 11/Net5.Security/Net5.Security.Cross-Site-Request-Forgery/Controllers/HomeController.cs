using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Net5.Security.Cross_Site_Request_Forgery.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.Security.Cross_Site_Request_Forgery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AccountController _accountController;
        private TransfersController _transfersController;

        public HomeController(
            ILogger<HomeController> logger,
            AccountController accountController,
            TransfersController transfersController
            )
        {
            _logger = logger;
            _accountController = accountController;
            _transfersController=transfersController;
        }

        public IActionResult Index()
        {
            ViewBag.Balance = _transfersController.Balance();
            ViewBag.IsAuthenticated = _accountController.IsAuthenticated();
            return View();
        }
        [HttpPost]
        public IActionResult Debit(int amount)
        {
            _transfersController.Debit(amount);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Credit(int amount)
        {
            _transfersController.Credit(amount);
            return RedirectToAction(nameof(Index));
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

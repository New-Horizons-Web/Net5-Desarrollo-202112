using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Net5.Security.Cross_Site_Request_Forgery.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IServiceProvider _service;
        public HttpContext Context { get{ return _service.GetRequiredService<IHttpContextAccessor>().HttpContext; } }
        public AccountController(IServiceProvider service)
        {
            _service=service;
        }

        [HttpGet]
        public bool IsAuthenticated()
        {
            return Context.Request.Cookies["IsAuthenticated"] == "1";
        }
        [HttpPost]
        public IActionResult Login()
        {
            Context.Response.Cookies.Append("IsAuthenticated", "1");
            return RedirectToAction(nameof(Index), "Home");
        }
        [HttpPost]
        public IActionResult Logout()
        {
            Context.Response.Cookies.Delete("IsAuthenticated");
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}

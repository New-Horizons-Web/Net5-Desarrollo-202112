using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Net5.Security.Cross_Site_Request_Forgery.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransfersController : ControllerBase
    {
        public IServiceProvider _service;
        public Microsoft.AspNetCore.Antiforgery.IAntiforgery _csrf { get { return _service.GetRequiredService<Microsoft.AspNetCore.Antiforgery.IAntiforgery>(); } }
        public HttpContext Context { get { return _service.GetRequiredService<IHttpContextAccessor>().HttpContext; } }

        public static int CurrentBalance = 100;

        public TransfersController(IServiceProvider service)
        {
            _service = service;
        }

        private async Task<bool> ValidateAntiForgeryToken()
        {
            try
            {
                await _csrf.ValidateRequestAsync(Context);
                return true;
            }
            catch (Microsoft.AspNetCore.Antiforgery.AntiforgeryValidationException)
            {
                return false;                
            }
        }

        [HttpGet]
        public int Balance()
        {
            return CurrentBalance;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public int Debit([FromForm]int amount)
        {
            CurrentBalance -= amount;
            return Balance();
        }
        [HttpPost]
        public int Credit([FromForm] int amount)
        {
            CurrentBalance += amount;
            return Balance();
        }
    }
}

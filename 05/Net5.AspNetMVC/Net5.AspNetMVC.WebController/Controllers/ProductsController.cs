using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Net5.AspNetMVC.WebController.Controllers
{
    public class ProductsController : Controller
    {        
        public ActionResult List()
        {
            return View();
        }

        [Route("Productos/Obtener")]
        public ActionResult Get()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Net5.AspNetMVC.WebController.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Article(int id)
        {
            return View();
        }
    }
}

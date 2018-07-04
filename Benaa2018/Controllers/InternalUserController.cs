using Microsoft.AspNetCore.Mvc;

namespace Benaa2018.Controllers
{
    public class InternalUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
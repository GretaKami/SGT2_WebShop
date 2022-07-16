using Microsoft.AspNetCore.Mvc;

namespace SGT2_WebShop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

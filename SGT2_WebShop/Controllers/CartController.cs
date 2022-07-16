using Microsoft.AspNetCore.Mvc;
using SGT2_WebShop.Extensions;
using WebShop_Services.Managers;

namespace SGT2_WebShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartManager _cartManager;
        private readonly ICartItemManager _cartItemManager;
        public CartController(ICartManager cartManager, ICartItemManager cartItemManager)
        {
            _cartManager = cartManager;
            _cartItemManager = cartItemManager;

        }

        [HttpGet]
        public IActionResult Index()
        {
            var cartModel = _cartManager.GetCartFromDb((int)HttpContext.Session.GetUserId())
                                        .ToModel();
            
            return View(cartModel);
        }

        [HttpPost]
        public IActionResult IncreaseQuantity(int productId)
        {
            var userId = (int)HttpContext.Session.GetUserId();

            _cartItemManager.IncreaseQuantity(userId, productId);

            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult SubtractQuantity(int productId)
        {
            var userId = (int)HttpContext.Session.GetUserId(); 

            _cartItemManager.SubtractQuantity(userId, productId);

            return RedirectToAction("Index");

        }


    }
}

using Microsoft.AspNetCore.Mvc;
using SGT2_WebShop.Extensions;
using SGT2_WebShop.Models;
using WebShop_Services.Managers;

namespace SGT2_WebShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartManager _cartManager;
        private readonly IOrderManager _orderManager;

        public OrderController(ICartManager cartManager, IOrderManager orderManager)
        {
            _cartManager = cartManager;
            _orderManager = orderManager;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var userId = (int)HttpContext.Session.GetUserId();

            var cartModel = _cartManager.GetCartFromDb(userId).ToModel();

            return View(cartModel);
        }


        [HttpPost]
        public IActionResult OrderConfirmation()
        {
            var userId = (int)HttpContext.Session.GetUserId();

            var cart = _cartManager.GetCartFromDb(userId);

            _orderManager.AddOrderToDb(cart);

            _cartManager.ClearCartItems(cart);

            return RedirectToAction("Index", "Home");
        }

    }
}

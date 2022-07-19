using Microsoft.EntityFrameworkCore;
using WebShop_DataAccess.Context;
using WebShop_DataAccess.Context.Entities;

namespace WebShop_Services.Managers
{
    public class CartManager : ICartManager
    {
        private readonly WebShopDbContext _context;
        public CartManager(WebShopDbContext context)
        {
            _context = context;
        }

        public void CreateNewCart(int userId)
        {            
            var Cart = new Cart
            {
                UserId = userId
            };

            _context.Carts.Add(Cart);
            _context.SaveChanges();
        }

        public Cart GetCartFromDb(int userID)
        {
            var cart = _context.Carts.Include(cart => cart.Items)
                                     .ThenInclude(item => item.Product)
                                     .FirstOrDefault(c => c.UserId == userID);

            return cart;
        }

        public void ClearCartItems(Cart cart)
        {
            foreach(var item in cart.Items)
            {
                _context.Cart_Items.Remove(item);
            }

            _context.SaveChanges();
        }
    }
}

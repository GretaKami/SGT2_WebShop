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

        public void CreateNewCart(User user)
        {            
            var Cart = new Cart
            {
                UserId = user.Id,
                User = user
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

    }
}

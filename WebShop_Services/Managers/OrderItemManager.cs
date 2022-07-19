
using WebShop_DataAccess.Context;
using WebShop_DataAccess.Context.Entities;

namespace WebShop_Services.Managers
{
    public class OrderItemManager : IOrderItemManager
    {
        private readonly WebShopDbContext _context;

        public OrderItemManager(WebShopDbContext context)
        {
            _context = context;
        }
        public OrderItem NewOrderItemFromCartItem(CartItem cartItem)
        {
           OrderItem orderItem = new OrderItem
           {
               ProductId = cartItem.ProductId,
               Product = cartItem.Product,
               Quantity = cartItem.Quantity

           };

           return orderItem;
        }
    }
}

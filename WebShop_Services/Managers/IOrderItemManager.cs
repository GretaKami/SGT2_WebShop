
using WebShop_DataAccess.Context.Entities;

namespace WebShop_Services.Managers
{
    public interface IOrderItemManager
    {
        public OrderItem NewOrderItemFromCartItem(CartItem cartItem);
    }
}

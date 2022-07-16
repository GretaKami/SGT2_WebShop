using WebShop_DataAccess.Context.Entities;

namespace WebShop_Services.Managers
{
    public interface ICartItemManager
    {
        public List<CartItem> GetCartItemsForCart(int cartId);

        public void AddNewCartItem(int productId, int userId);

        public bool IsItemInCart(int productId, int userId);

        public void IncreaseQuantity(int userId, int productId);

        public void SubtractQuantity(int userId, int productId);

        public void RemoveItem(int userId, int productId);

        public CartItem GetCartItemById(int userID, int productId);
    }
}

using WebShop_DataAccess.Context.Entities;

namespace WebShop_Services.Managers
{
    public interface ICartManager
    {
        public Cart GetCartFromDb(int userID);

        public void CreateNewCart(int userId);

        public void ClearCartItems(Cart cart);

    }
}

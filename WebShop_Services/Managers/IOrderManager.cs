using WebShop_DataAccess.Context.Entities;

namespace WebShop_Services.Managers
{
    public interface IOrderManager
    {
        public void AddOrderToDb(Cart cart);

        public float CalculateOrderSum(Cart cart);

        public List<OrderItem> GetOrderItems(Cart cart);

    }
}

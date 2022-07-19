using WebShop_DataAccess.Context;
using WebShop_DataAccess.Context.Entities;

namespace WebShop_Services.Managers
{
    public class OrderManager : IOrderManager
    {
        private readonly WebShopDbContext _context;
        private readonly IOrderItemManager _orderItemManager;
        public OrderManager(WebShopDbContext context, IOrderItemManager orderItemManager)
        {
            _context = context;
            _orderItemManager = orderItemManager;
        }

        public List<OrderItem> GetOrderItems(Cart cart)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (var item in cart.Items)
            {
                OrderItem orderItem = _orderItemManager.NewOrderItemFromCartItem(item);
                orderItems.Add(orderItem);
            }

            return orderItems;
        }

        public void AddOrderToDb(Cart cart)
        {
            float sum = CalculateOrderSum(cart);
            List<OrderItem> orderItems = GetOrderItems(cart);

            var order = new Order
            {
                UserId = cart.UserId,
                Sum = sum,
                PurchaseDate = DateTime.Now,
                Items = orderItems
            };

            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public float CalculateOrderSum(Cart cart)
        {
            float sum = 0;

            foreach(var item in cart.Items)
            {
                sum += item.Quantity * item.Product.Price;
            }

            return sum;
        }

    }
}

namespace SGT2_WebShop.Models
{
    public class CartModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public List<CartItemModel> Items { get; set; }
    }
}

namespace SGT2_WebShop.Models
{
    public class CartItemModel
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public ProductModel Product { get; set; }

        public int Quantity { get; set; }

        public float TotalPrice { get; set; }
    }
}

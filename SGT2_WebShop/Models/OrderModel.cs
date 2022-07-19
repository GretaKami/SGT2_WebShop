using WebShop_DataAccess.Context.Entities;

namespace SGT2_WebShop.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public List<CartItem> Items { get; set; }

        public float Sum { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}

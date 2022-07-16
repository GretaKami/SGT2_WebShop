using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_DataAccess.Context.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public List<User> Users { get; set; }

        public List<CartItem> Items { get; set; }

        public float Sum { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string DeliveryAddress { get; set; }

        
    }
}

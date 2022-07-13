using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_DataAccess.Context.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public Subcategory Subcategory { get; set; }

        public string? ImageName { get; set; }
        public byte[]? Image { get; set; }


    }
}

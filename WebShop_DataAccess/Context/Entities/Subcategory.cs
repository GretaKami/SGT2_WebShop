using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_DataAccess.Context.Entities
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public List<Product> Products { get; set; }
    }
}

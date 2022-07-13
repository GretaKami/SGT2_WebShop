using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_DataAccess.Context.Entities;

namespace WebShop_Services.Managers
{
    public interface IProductManager
    {
        public List<Product> GetProductsFromDb();

        public void AddProduct(Product product, int selectedSubcategoryId);

    }
}

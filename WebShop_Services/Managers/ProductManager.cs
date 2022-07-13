using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_DataAccess.Context;
using WebShop_DataAccess.Context.Entities;

namespace WebShop_Services.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly WebShopDbContext _context;

        public ProductManager(WebShopDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product, int selectedSubcategoryId)
        {
            product.Subcategory = _context.Subcategories.First(s=> s.Id.Equals(selectedSubcategoryId));

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public List<Product> GetProductsFromDb()
        {
            List<Product> products = _context.Products.Include(p=>p.Subcategory.Category).ToList();

            return products;
        }
    }
}

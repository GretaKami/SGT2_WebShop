using Microsoft.AspNetCore.Mvc;
using SGT2_WebShop.Extensions;
using SGT2_WebShop.Models;
using WebShop_DataAccess.Context.Entities;
using WebShop_Services.Managers;

namespace SGT2_WebShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;

        List<ProductModel> productList;
        public ProductController(IProductManager productManager, ICategoryManager categoryManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;

            productList = _productManager.GetProductsFromDb().Select(p => p.ToModel()).ToList();
        }
        public IActionResult Index()
        {
            productList.Sort((x, y) => y.Price.CompareTo(x.Price));
            return View(productList);
        }

        public IActionResult View(int id)
        {
            var product = productList.Find(product => product.Id == id);

            return View(product);
        }

        [HttpGet]
        public IActionResult NewProduct()
        {
            NewProductModel newProduct = new NewProductModel();

            newProduct.Subcategories = _categoryManager.GetSubcategoriesFromDb()
                .Select(s => s.ToModelForProduct()).ToList();

            return View(newProduct);
        }

        [HttpPost]
        public IActionResult NewProduct(NewProductModel product)
        {
            ModelState.Remove(nameof(product.Subcategories));
            ModelState.Remove(nameof(product.FilePath));
            ModelState.Remove(nameof(product.Image));

            if (ModelState.IsValid)
            {
                // getting file original name
                string fileName = product.Image.FileName;

                // combining GUID to create unique name before saving in wwwroot
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;

                // getting full path inside wwwroot/images
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Photos", fileName);

                // copying file -> saves a copy in wwwroot folder
                product.Image.CopyTo(new FileStream(imagePath, FileMode.Create));

                // converting image file to blob
                byte[] file;
                using (var ms = new MemoryStream())
                {
                    product.Image.CopyTo(ms);
                    file = ms.ToArray();
                }

                Product newProduct = new Product
                {
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    ImageName = fileName,
                    Image = file

                };

                _productManager.AddProduct(newProduct, product.SelectedSubcategoryId);
                return RedirectToAction("Index");

            }

            product.Subcategories = _categoryManager.GetSubcategoriesFromDb()
                .Select(s => s.ToModelForProduct()).ToList();

            return View(product);
        }
    }
}

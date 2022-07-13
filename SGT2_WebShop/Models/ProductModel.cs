using System.ComponentModel.DataAnnotations;

namespace SGT2_WebShop.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public SubcategoryModel Subcategory { get; set; }

        public string? Blob { get; set; }

        public string? ImageName { get; set; }
    }
}

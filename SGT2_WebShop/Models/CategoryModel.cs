using System.ComponentModel.DataAnnotations;

namespace SGT2_WebShop.Models
{
    public class CategoryModel
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        public List<SubcategoryModel>? Subcategories { get; set; }
    }
}

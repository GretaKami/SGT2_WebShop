using System.ComponentModel.DataAnnotations;

namespace SGT2_WebShop.Models
{
    public class NewProductModel
    {
        [Required]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }
        
        public List<SubcategoryModel> Subcategories { get; set; }

        public int SelectedSubcategoryId { get; set; }

        public IFormFile Image { get; set; }

        public string FilePath { get; set; }
    }
}

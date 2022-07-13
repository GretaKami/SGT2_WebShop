using System.ComponentModel.DataAnnotations;

namespace SGT2_WebShop.Models
{
    public class NewSubcategoryModel
    {
        [Required]
        public string Title { get; set; }

        public List<CategoryModel> Categories { get; set; }

        [Required]
        public int SelectedCategoryId { get; set; }
    }
}

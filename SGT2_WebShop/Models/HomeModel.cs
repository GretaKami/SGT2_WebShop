namespace SGT2_WebShop.Models
{
    public class HomeModel
    {
        public List<CategoryModel> Categories { get; set; }

        public SubcategoryModel SelectedSubcategory { get; set; }

        public int SelectedProductId { get; set; }
    }
}

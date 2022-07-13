namespace SGT2_WebShop.Models
{
    public class SubcategoryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public CategoryModel Category { get; set; }
        public List<ProductModel>? Products { get; set; }
    }
}

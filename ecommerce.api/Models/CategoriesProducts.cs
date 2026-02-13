namespace ecommerce.api.Models
{
    public class CategoriesProducts
    {
        public string CategoriesId { get; set; }
        public Categories Categories { get; set; }
        public string ProductsId { get; set; }
        public Products Products { get; set; }
    }
}

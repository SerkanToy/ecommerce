namespace ecommerce.api.Models
{
    public class ProductsTags
    {
        public string ProductsId { get; set; }
        public Products Products { get; set; }
        public string TagsId { get; set; }
        public Tags Tags { get; set; }
    }
}

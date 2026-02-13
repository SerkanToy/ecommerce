namespace ecommerce.api.Models
{
    public class ProductsCoupons
    {
        public string ProductsId { get; set; }
        public Products Products { get; set; }
        public string CouponsId { get; set; }
        public Coupons Coupons { get; set; }
    }
}

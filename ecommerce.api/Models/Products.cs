namespace ecommerce.api.Models
{
    public class Products
    {
        public Products()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int RegularPrice { get; set; } = 0;
        public int DiscountPrice { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public bool isActive { get; set; } = true;
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public string? UpdateDate { get; set; }
        public string? DeleteBy { get; set; }
        public string? DeleteDate { get; set; }
        public ICollection<ProductsTags> ProductsTags { get; set; }
        public ICollection<CategoriesProducts> CategoriesProducts { get; set; }
        public ICollection<Galleries> Galleries { get; set; }
        public ICollection<ProductsCoupons> ProductsCoupons { get; set; }
    }
}

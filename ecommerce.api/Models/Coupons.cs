namespace ecommerce.api.Models
{
    public class Coupons
    {
        public Coupons()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Code { get; set; }
        public string CouponDescription { get; set; }
        public string DiscountValue { get; set; }
        public string DiscountType { get; set; }
        public string TimesUsed { get; set; }
        public string MaxUsage { get; set; }
        public string CouponStartDate { get; set; }
        public string CouponEndDate { get; set; }
        public bool isActive { get; set; } = true;
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public string? UpdateDate { get; set; }
        public string? DeleteBy { get; set; }
        public string? DeleteDate { get; set; }
        public ICollection<ProductsCoupons> ProductsCoupons { get; set; }
    }
}

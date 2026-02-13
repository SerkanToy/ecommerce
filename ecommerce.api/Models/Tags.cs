namespace ecommerce.api.Models
{
    public class Tags
    {
        public Tags()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; } = true;
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public string? UpdateDate { get; set; }
        public string? DeleteBy { get; set; }
        public string? DeleteDate { get; set; }
        public ICollection<ProductsTags> ProductsTags { get; set; }
    }
}

namespace ecommerce.api.Models
{
    public class Galleries
    {
        public Galleries()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public Products Products { get; set; }
        public string ProductsId { get; set; }
        public string ImagePath { get; set; }
        public bool Thumbnail { get; set; }
        public int DisplayOrder { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public string? UpdateDate { get; set; }
        public string? DeleteBy { get; set; }
        public string? DeleteDate { get; set; }
    }
}

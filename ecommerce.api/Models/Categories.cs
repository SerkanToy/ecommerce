namespace ecommerce.api.Models
{
    public class Categories
    {
        public Categories()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string? CategoriesId { get; set; }
        public Categories? Categori { get; set; }
        public ICollection<Categories>? Categoris { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public string? ImagePath { get; set; }
        public bool isActive { get; set; } = true;
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public string? UpdateDate { get; set; }
        public string? DeleteBy { get; set; }
        public string? DeleteDate { get; set; }
        public ICollection<CategoriesProducts> CategoriesProducts { get; set; }
    }
}

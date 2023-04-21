namespace MyWebsite.Models.ViewModel
{
    public class CategoryVm
    {
        public Category Category { get; set; } = new Category();
        public IEnumerable<Category> categories { get; set; } = new List<Category>();
    }
}

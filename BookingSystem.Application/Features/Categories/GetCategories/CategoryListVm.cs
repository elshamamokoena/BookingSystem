namespace BookingSystem.Application.Features.Categories.GetCategories
{
    public class CategoryListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
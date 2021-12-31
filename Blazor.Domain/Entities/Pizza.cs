namespace Blazor.Domain.Entities
{
    public class Pizza : EntityBase
    {
        public string? Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public string? Size { get; set; } = null!;
        public int Price { get; set; }
        public string? ImagePath { get; set; } = null!;
        public string? ImageName { get; set; } = null!;
    }
}

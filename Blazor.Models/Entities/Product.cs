namespace Blazor.Models.Entities
{
    public class Product : EntityBase
    {
        public string? Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public decimal? Price { get; set; } = null!;
        public int Amount { get; set;}
        public string? Brand { get; set; } = null!;

        public Size? Size { get; set; }
        public Colour? Colour { get; set; }
    }
}

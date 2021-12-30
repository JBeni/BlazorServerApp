namespace Blazor.Domain.Entities
{
    public class Product : EntityBase
    {
        public string? Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public int Price { get; set; }
        public int Amount { get; set;}
        public string? Brand { get; set; } = null!;

        public Size? Size { get; set; }
        public Colour? Colour { get; set; }
    }
}

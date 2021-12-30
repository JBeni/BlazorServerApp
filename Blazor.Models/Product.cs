using Blazor.Models.Common;

namespace Blazor.Models
{
    public class Product : EntityBase
    {
        public string? Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public decimal? Price { get; set; } = null!;
        public decimal? Amount { get; set;} = null!;
        public string? Brand { get; set; } = null!;

        public Size? Size { get; set; }
        public Colour? Colour { get; set; }
    }
}

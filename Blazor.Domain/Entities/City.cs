namespace Blazor.Domain.Entities
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string? CityName { get; set; }
    }
}

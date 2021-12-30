namespace Blazor.Models.Entities
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CityId { get; set; }
        public string? CityName { get; set; }
    }
}

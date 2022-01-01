namespace Blazor.Domain.Responses
{
    public class PizzaResponse : IMapFrom<Pizza>
    {
        public int Id { get; set; }
        public string? Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public string? Size { get; set; } = null!;
        public int Price { get; set; }
        public string? ImagePath { get; set; } = null!;
        public string? ImageName { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pizza, PizzaResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.Size, opt => opt.MapFrom(s => s.Size))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.ImageName, opt => opt.MapFrom(s => s.ImageName))
                .ForMember(d => d.ImagePath, opt => opt.MapFrom(s => s.ImagePath));
        }

        public string? Error { get; set; }
    }
}

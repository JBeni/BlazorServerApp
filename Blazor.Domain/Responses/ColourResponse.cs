namespace Blazor.Domain.Responses
{
    public class ColourResponse : IMapFrom<Colour>
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Colour, ColourResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }

        public string? Error { get; set; }

    }
}

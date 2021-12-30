namespace Blazor.Data.Responses
{
    public class SizeResponse : IMapFrom<Size>
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Size, SizeResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }

        public string? Error { get; set; }
    }
}

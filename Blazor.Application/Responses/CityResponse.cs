namespace Blazor.Application.Responses
{
    public class CityResponse : IMapFrom<City>
    {
        public int CityId { get; set; }
        public string? CityName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<City, CityResponse>()
                .ForMember(d => d.CityId, opt => opt.MapFrom(s => s.CityId))
                .ForMember(d => d.CityName, opt => opt.MapFrom(s => s.CityName));
        }

        public string? Error { get; set; }
    }
}

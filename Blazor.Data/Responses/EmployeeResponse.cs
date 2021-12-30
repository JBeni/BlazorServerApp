namespace Blazor.Data.Responses
{
    public class EmployeeResponse : IMapFrom<Employee>
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string Gender { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeResponse>()
                .ForMember(d => d.EmployeeId, opt => opt.MapFrom(s => s.EmployeeId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.City, opt => opt.MapFrom(s => s.City))
                .ForMember(d => d.Department, opt => opt.MapFrom(s => s.Department))
                .ForMember(d => d.Gender, opt => opt.MapFrom(s => s.Gender));
        }

        public string? Error { get; set; }
    }
}

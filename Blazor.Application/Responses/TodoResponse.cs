namespace Blazor.Application.Responses
{
    public class TodoResponse : IMapFrom<Todo>
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public bool IsCompleted { get; set; } = false;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Todo, TodoResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.IsCompleted, opt => opt.MapFrom(s => s.IsCompleted))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title));
        }

        public string? Error { get; set; }
    }
}

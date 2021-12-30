namespace Blazor.Domain.Entities
{
    public class Todo : EntityBase
    {
        public string Title { get; set; } = null!;
        public bool IsCompleted { get; set; } = false;
    }
}

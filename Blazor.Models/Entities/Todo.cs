namespace Blazor.Models.Entities
{
    public class Todo : EntityBase
    {
        public string Title { get; set; } = null!;
        public bool IsCompleted { get; set; } = false;
    }
}

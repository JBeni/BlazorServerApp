using Blazor.Models.Common;

namespace Blazor.Models
{
    public class Todo : EntityBase
    {
        public string Title { get; set; } = null!;
        public bool IsCompleted { get; set; } = false;
    }
}

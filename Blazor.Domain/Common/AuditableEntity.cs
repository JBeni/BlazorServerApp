namespace Blazor.Domain.Common
{
    public class AuditableEntity : EntityBase
    {
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}

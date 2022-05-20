using CleanArchitecture.DotNet6.Domain.Common;

namespace CleanArchitecture.DotNet6.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}

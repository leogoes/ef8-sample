using EfCore.Core.Entities.Abstractions;

namespace EfCore.Core.Enities
{
    public class Person : IAggregateRoot
    {
        public Guid Id { get; set; }
        public Guid DreamId { get; set; }
        public Dream? Dream { get; set; }
        public virtual IEnumerable<Sleep>? Sleeps { get; set; }
    }
}

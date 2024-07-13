using EfCore.Core.Entities;
using EfCore.Core.Entities.Abstractions;

namespace EfCore.Core.Enities
{
    public class Sleep : IEntity
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public DateTime? SleptAt { get; set; }
        public DateTime? WokeupAt { get; set; }
        public virtual IEnumerable<Sheep>? CountOfSheeps { get; set; }
        public NoiseDuringSleep? Noise { get; set; }
        public virtual Person? Person { get; set; }
    }
}

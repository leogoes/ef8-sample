using EfCore.Core.Entities.Abstractions;

namespace EfCore.Core.Enities
{
    public class Sheep : IValueObject
    {
        public Guid Id { get; set; }
        public Guid SleepId { get; set; }
        public uint Name { get; set; }
        public uint Number { get; set; }
    }
}

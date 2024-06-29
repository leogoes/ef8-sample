using EfCore.Core.Entities.Abstractions;

namespace EfCore.Core.Entities
{
    public class NoiseDuringSleep : IValueObject
    {
        public bool HasNoiseAtKitchen { get; set; }
    }
}

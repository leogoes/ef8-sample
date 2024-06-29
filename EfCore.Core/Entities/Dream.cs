using EfCore.Core.Entities.Abstractions;

namespace EfCore.Core.Enities
{
    public class Dream : IEntity
    {
        public Guid Id { get; set; }
        public string? Theme { get; set; }
        public bool? CanPunch { get; set; }
        public IEnumerable<Person>? Peoples { get; set; }
    }
}

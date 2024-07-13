using EfCore.Core.Entities.Abstractions;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EfCore.Core.Entities
{
    public class Dream : IEntity
    {
        public Guid Id { get; set; }
        public string? Theme { get; set; }
        public bool? CanPunch { get; set; }

        private IEnumerable<Person> _peoples;

        //public IEnumerable<Person>? Peoples { get => LazyLoader.Load(this, ref _peoples); set => _peoples = value; }

        public IEnumerable<Person>? Peoples
        {
            get
            {
                _lazyLoader?.Invoke(this, nameof(Peoples)); return _peoples;
            }
            set => _peoples = value;
        }

        private ILazyLoader LazyLoader { get; set; }
        private Action<object, string> _lazyLoader { get; set; }

        public Dream() { }

        //public Dream(ILazyLoader lazyLoader) => LazyLoader = lazyLoader;

        public Dream(Action<object, string> lazyLoader) => _lazyLoader = lazyLoader;
    }
}

using EfCore.Core.DbContexts;

namespace EfCore.Core.QueryProducers
{
    public class QueryProjections
    {
        public object DreamProjection(CustomContext context)
        {
            return context.Dreams.Select(x => new { x.Id }).First();
        }
    }
}

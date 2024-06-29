using EfCore.Core.DbContexts;

namespace EfCore.Core.EnsureCreateds
{
    public class Ensurance(CustomContext context)
    {
        /// <summary>
        /// EnsureCreated criará o banco de dados se ele não existir e inicializará o esquema de banco de dados. 
        /// Se houver tabelas (incluindo tabelas para outra classe DbContext), o esquema não será inicializado.
        /// </summary>
        /// <returns></returns>
        public bool EnsureCreated() => context.Database.EnsureCreated();

        /// <summary>
        /// O método EnsureDeleted removerá o banco de dados se ele existir. 
        /// Se você não tiver as permissões apropriadas, uma exceção será gerada.
        /// </summary>
        /// <returns></returns>
        public bool EnsureDeleted() => context.Database.EnsureDeleted();
    }
}

using EfCore.Core.DbContexts;
using EfCore.Core.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Core.DataLoadTypes
{
    public class ExplicityLoading
    {
        private readonly static Guid DreamId = Guid.Parse("08dca34f-f633-4da2-8d30-742d03452deb");

        public static async Task Load(CustomContext context)
        {
            if (!context.Dreams.Any())
            {
                await GoesToSleepService.GoesToSleep(context);
            }

            //Add to List or add MultiActiveResultSets on ConnectionString to avoid InvalidOperationException
            var dreams = context.Dreams.ToList();

            foreach (var dream in dreams)
            {
                if (dream.Id == DreamId)
                {
                    context.Entry(dream).Collection(x => x.Peoples).Load();
                    //context.Entry(dream).Collection(x => x.Peoples).Query().Where(x => x.DreamId == DreamId);
                }

                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine($"Sonho - Id: {dream.Id}, Sonho: {dream.Theme}, Posso dar socos: {dream.CanPunch}");

                if (dream.Peoples is not null && dream.Peoples.Any())
                {
                    foreach (var person in dream.Peoples)
                    {
                        Console.WriteLine($"Pessoa - Id: {person.Id}, Id Sonho: {person.DreamId}");
                    }
                }
                else
                {
                    Console.WriteLine($"Não tem nenhuma pessoa sonhando esse sonho.");
                }
                Console.WriteLine("--------------------------------------------------------------------------------");
            }
        }
    }
}

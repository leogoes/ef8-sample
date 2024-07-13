using EfCore.Core.DbContexts;
using EfCore.Core.Seeds;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Core.DataLoadTypes
{
    public class EagerLoading
    {
        public static async Task Load(CustomContext context)
        {
            if (!context.Dreams.Any())
            {
                await GoesToSleepService.GoesToSleep(context);
            }

            var dreams = context.Dreams
                                .Include(x => x.Peoples);

            foreach (var dream in dreams)
            {
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

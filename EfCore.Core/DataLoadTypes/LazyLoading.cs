using EfCore.Core.DbContexts;
using EfCore.Core.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Core.DataLoadTypes
{
    public class LazyLoading
    {
        public static async Task Load(CustomContext context)
        {
            if (!context.Dreams.Any())
            {
                await GoesToSleepService.GoesToSleep(context);
            }

          //  context.ChangeTracker.LazyLoadingEnabled = false;

            var dreams = context.Dreams;

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

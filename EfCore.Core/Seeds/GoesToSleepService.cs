using EfCore.Core.DbContexts;
using EfCore.Core.Enities;
using EfCore.Core.Entities;

namespace EfCore.Core.Services
{
    public class GoesToSleepService
    {
        public static async Task GoesToSleep(CustomContext context)
        {
            var me = GoesToSleep();

            await context.Peoples.AddAsync(me);

            await context.SaveChangesAsync();
        }

        public static Person GoesToSleep()
        {
            var Me = new Person();

            var triesToSleep = new Sleep();

            Me.Sleeps = [triesToSleep];

            var haveToCountSheep = CountOneMoreSheep();

            triesToSleep.Noise = HeardNoiseInKitchen();

            var haveToCountSheepOneMore = CountOneMoreSheep(haveToCountSheep);

            triesToSleep.CountOfSheeps = [haveToCountSheep, haveToCountSheepOneMore];

            triesToSleep.SleptAt = DateTime.UtcNow.AddMinutes(10);

            Me.Dream = HavingBadDream();

            return Me;
        }

        private static NoiseDuringSleep HeardNoiseInKitchen()
        {
            return new NoiseDuringSleep
            {
                HasNoiseAtKitchen = true
            };
        }

        private static Dream HavingBadDream()
        {
            return new Dream
            {
                CanPunch = false,
                Theme = "Horror"
            };
        }

        private static Sheep CountOneMoreSheep(Sheep? lastSheep = null)
        {

            if (lastSheep is null)
                return new Sheep
                {
                    Name = 1,
                    Number = 1
                };

            return new Sheep
            {
                Name = lastSheep.Name + 1,
                Number = lastSheep.Number + 1
            };
        }
    }
}

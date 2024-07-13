﻿using EfCore.Core.DbContexts;
using EfCore.Core.Entities;

namespace EfCore.Core.Seeds
{
    public class GoesToSleepService
    {
        public static async Task GoesToSleep(CustomContext context)
        {
            var me = GoesToSleep();
            var someoneElse = GoesToSleep();

            await context.Peoples.AddAsync(me);
            await context.Peoples.AddAsync(someoneElse);

            await context.SaveChangesAsync();
        }

        public static Person GoesToSleep()
        {
            var Me = new Person();

            var triesToSleep = new Sleep();

            Me.Sleeps = [triesToSleep];

            var haveToCountSheep = CountOneMoreSheep();

            triesToSleep.SleptAt = DateTime.UtcNow.AddMinutes(10);

            triesToSleep.Noise = HeardNoiseInKitchen();

            triesToSleep.WokeupAt = DateTime.UtcNow.AddMinutes(10);

            var haveToCountSheepOneMore = CountOneMoreSheep(haveToCountSheep);

            triesToSleep.SleptAt = DateTime.UtcNow.AddMinutes(10);

            triesToSleep.CountOfSheeps = [haveToCountSheep, haveToCountSheepOneMore];

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

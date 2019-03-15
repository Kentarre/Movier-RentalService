using System;
using Common.DataTypes.Enums;

namespace CalculationService.Helpers
{
    public static class Calculation
    {
        public static decimal GetPrice(FilmType type, int durationDays, int daysDiscounted, bool useBonuses)
        {
            int tempDays;

            if (durationDays == 0)
                throw new Exception();

            durationDays = useBonuses ? durationDays - daysDiscounted : durationDays;

            if (durationDays < 1)
                return 0;

            switch (type)
            {
                case FilmType.NewRelease:
                    return 40M * durationDays;
                case FilmType.Regular:
                    if (durationDays <= 3)
                        return 30M;

                    tempDays = durationDays - 3;
                    return (tempDays * 30) + 30;
                default:
                    if (durationDays <= 5)
                        return 30M;

                    tempDays = durationDays - 5;
                    return (tempDays * 30) + 30;
            }
        }


        public static int CreateNewBonus(FilmType type)
        {
            switch (type)
            {
                case FilmType.NewRelease:
                    return 2;
                default:
                    return 1;
            }
        }
    }
}

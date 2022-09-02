using System;

namespace Mayhem.Helper
{
    public class BonusHelper
    {
        private const int DecimalPlacesNumber = 6;

        public static double IncreaseBonusValue(double bonus, double baseValue, double value)
        {
            return ChangeBonusValue(bonus, baseValue, value, true);
        }

        public static double DecreaseBonusValue(double bonus, double baseValue, double value)
        {
            return ChangeBonusValue(bonus, baseValue, value, false);
        }

        private static double ChangeBonusValue(double bonus, double baseValue, double value, bool increase)
        {
            double percentageBonus = GetPercentageBonus(bonus);
            double valueBonus = baseValue * percentageBonus;

            if (increase)
            {
                return Math.Round(value + valueBonus, DecimalPlacesNumber);
            }
            else
            {
                return Math.Round(value - valueBonus, DecimalPlacesNumber);
            }
        }

        private static double GetPercentageBonus(double bonus)
        {
            return bonus / 100d;
        }
    }
}

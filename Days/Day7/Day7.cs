using AoC2021.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2021.Days
{
    class Day7
    {
        private static List<string> input;
        static Day7()
        {
            input = Utilities.Instance.GetInput(nameof(Day7));
        }


        public static void SolvePartOne()
        {
            List<int> crabs = input[0].Split(',').Select(int.Parse).ToList();
            int leftmostCrab = crabs.Min();
            int rightmostCrab = crabs.Max();

            long leatFuelSum = long.MaxValue;
            int fuelSum = 0;

            for (int i = leftmostCrab; i < rightmostCrab; i++)
            {
                fuelSum = 0;
                foreach (int crab in crabs)
                {
                    fuelSum += Math.Abs(i - crab);
                }
                if (fuelSum < leatFuelSum)
                {
                    leatFuelSum = fuelSum;
                }
            }

            Utilities.Instance.OutputAnswer(7, leatFuelSum.ToString());
        }

        public static void SolvePartTwo()
        {
            List<int> crabs = input[0].Split(',').Select(int.Parse).ToList();
            int leftmostCrab = crabs.Min();
            int rightmostCrab = crabs.Max();

            long leatFuelSum = long.MaxValue;
            int fuelSum = 0;

            for (int i = leftmostCrab; i < rightmostCrab; i++)
            {
                fuelSum = 0;
                foreach (int crab in crabs)
                {
                    if (Math.Abs(i - crab)  <= 1)
                    {
                        fuelSum += Math.Abs(i - crab);
                    }
                    else
                    {
                        fuelSum += FuelBurningCalculation(Math.Abs(i - crab),1,0);
                    }
                }
                if (fuelSum < leatFuelSum)
                {
                    leatFuelSum = fuelSum;
                }
            }

            Utilities.Instance.OutputAnswer(7, leatFuelSum.ToString());
        }

        private static int FuelBurningCalculation(int distance, int previousValue, int currentValue)
        {
            int total = currentValue + previousValue;

            if (distance > 1)
            {
                int nextValue = previousValue + 1;
                int nextCount = distance - 1;
                total = FuelBurningCalculation(nextCount, nextValue, total);
            }
            return total;

        }
    }
}

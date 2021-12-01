using AoC2021.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2021.Days
{
    class Day1
    {
        private static List<int> input;
        static Day1()
        {
            input = Utilities.Instance.GetInput(nameof(Day1)).Select(int.Parse).ToList();
            
        }

        public static void SolvePartOne()
        {
            int count = 0;
            int previousValue = -9000;
            int currentMeasurement = 0;
            foreach (int item in input)
            {
                currentMeasurement = item;
                if (previousValue != -9000)
                {
                    if (previousValue < currentMeasurement)
                    {
                        count++;
                    }
                }
                previousValue = item;
            }
            Utilities.Instance.OutputAnswer(1, count.ToString());
        }

        public static void SolvePartTwo()
        {
            int count = 0;

            for (int i = 0; i < input.Count; i++)
            {
                if (i+3 <= input.Count-1)
                {
                    if (input[i] + input[i + 1] + input[i + 2] < input[i + 1] + input[i + 2] + input[i + 3])
                    {
                        count++;
                    }
                }
                
            }

            Utilities.Instance.OutputAnswer(1, count.ToString());
        }
    }
}

using AoC2021.HelperClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2021.Days
{
    class Day2
    {
        private static List<string> input;
        static Day2()
        {
            input = Utilities.Instance.GetInput(nameof(Day2));
        }


        public static void SolvePartOne()
        {
            int horizon = 0;
            int depth = 0;

            foreach (string command in input)
            {
                string[] commandString = command.Split(" ");
                switch (commandString[0])
                {
                    case "forward":
                        horizon += int.Parse(commandString[1]);
                        break;
                    case "down":
                        depth += int.Parse(commandString[1]);
                        break;
                    case "up":
                        depth -= int.Parse(commandString[1]);
                        break;
                    default:
                        break;
                }
            }

            Utilities.Instance.OutputAnswer(2, (horizon * depth).ToString());
        }

        public static void SolvePartTwo()
        {
            int horizon = 0;
            int depth = 0;
            int aim = 0;

            foreach (string command in input)
            {
                string[] commandString = command.Split(" ");
                switch (commandString[0])
                {
                    case "forward":
                        horizon += int.Parse(commandString[1]);
                        depth += aim * int.Parse(commandString[1]);
                        break;
                    case "down":
                        aim += int.Parse(commandString[1]);
                        break;
                    case "up":
                        aim -= int.Parse(commandString[1]);
                        break;
                    default:
                        break;
                }
            }

            Utilities.Instance.OutputAnswer(2, (horizon * depth).ToString());
        }
    }
}

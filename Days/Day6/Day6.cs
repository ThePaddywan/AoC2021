using AoC2021.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2021.Days
{
    class Day6
    {
        private static List<string> input;
        static Day6()
        {
            input = Utilities.Instance.GetInput(nameof(Day6));
        }


        public static void SolvePartOne()
        {
            List<LanternFish> fish = new List<LanternFish>();
            List<string> fishList = new List<string>(input[0].Split(',').ToList());
            foreach (string item in fishList)
            {
                fish.Add(new LanternFish(int.Parse(item)));
            }


            //BRUTEFORCE WAY!
            //for (int i = 0; i < 79; i++)
            //{
            //    for (int o = 0; o < fish.Count-1; o++)
            //    {
            //        LanternFish currentFish = fish[i];
            //        currentFish.internalTimer--;
            //        switch (currentFish.internalTimer)
            //        {
            //            case -1:
            //                currentFish.Reset();
            //                fish.Add(new LanternFish());
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //}

            //Hit sack. IDea from last day. Group by and handle fish of  same internalTimer per day per run instead of looping trough everything
        }

        public static void SolvePartTwo()
        {

        }
    }
}

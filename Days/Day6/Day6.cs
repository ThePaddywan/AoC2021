using AoC2021.HelperClasses;
using System.Collections.Generic;
using System.Linq;

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

            //var s = fish.GroupBy(x => x.internalTimer).ToList();

            //s.Select(x => new { x.Key, d})

            //Using array because my LINQ if failling me!

            int[] internalTimerGrouped = new int[9];
            foreach (LanternFish item in fish)
            {
                internalTimerGrouped[item.internalTimer]++;
            }

            for (int i = 0; i < 80; i++)
            {
                int dyingFish = internalTimerGrouped[0];
                for (int o = 1; o <= 8; o++)
                    internalTimerGrouped[o - 1] = internalTimerGrouped[o];
                internalTimerGrouped[6] += dyingFish;
                internalTimerGrouped[8] = dyingFish;
            }

            Utilities.Instance.OutputAnswer(6, internalTimerGrouped.Sum().ToString());

        }

        public static void SolvePartTwo()
        {
            List<LanternFish> fish = new List<LanternFish>();
            List<string> fishList = new List<string>(input[0].Split(',').ToList());
            foreach (string item in fishList)
            {
                fish.Add(new LanternFish(int.Parse(item)));
            }

            long[] internalTimerGrouped = new long[9];
            foreach (LanternFish item in fish)
            {
                internalTimerGrouped[item.internalTimer]++;
            }

            for (int i = 0; i < 256; i++)
            {
                long dyingFish = internalTimerGrouped[0];
                for (int o = 1; o <= 8; o++)
                    internalTimerGrouped[o - 1] = internalTimerGrouped[o];
                internalTimerGrouped[6] += dyingFish;
                internalTimerGrouped[8] = dyingFish;
            }

            Utilities.Instance.OutputAnswer(6, internalTimerGrouped.Sum().ToString());
        }
    }
}

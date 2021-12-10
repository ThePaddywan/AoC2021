using AoC2021.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2021.Days
{
    class Day9
    {
        /// <summary>
        /// Refactoring: I DONT EVEN KNOW WHERE TO START! I started on something and I went too far to correct it. This is a mess.....
        /// </summary>
        private static List<string> input;
        private static List<Location> locations = new List<Location>();
        static Day9()
        {
            input = Utilities.Instance.GetInput(nameof(Day9));
        }


        public static void SolvePartOne()
        {

            List<Location> locations = new List<Location>();
            for (int i = 0; i < input.Count; i++)
            {
                for (int o = 0; o < input[0].Length; o++)
                {
                    Location location = GetLocationDetails(i, o);
                    location.CheckForLowPoint();
                    locations.Add(location);

                }

            }


            Utilities.Instance.OutputAnswer(9, locations.Where(x => x.isLowPoint == true).Sum(x => x.RiskLevel).ToString());

        }

        private static Location GetLocationDetails(int i, int o)
        {
            Location location;
            location = new Location();
            location.height = int.Parse(input[i][o].ToString());
            location.up = 99;
            location.down = 99;
            location.left = 99;
            location.right = 99;
            //First row
            if (i == 0)
            {
                if (o == 0)
                {

                    location.down = int.Parse(input[i + 1][o].ToString());
                    location.right = int.Parse(input[i][o + 1].ToString());
                    return location;
                }

                if (o == input[0].Length - 1)
                {
                    location.down = int.Parse(input[i + 1][o].ToString());
                    location.left = int.Parse(input[i][o - 1].ToString());
                    return location;
                }

                location.left = int.Parse(input[i][o - 1].ToString());
                location.down = int.Parse(input[i + 1][o].ToString());
                location.right = int.Parse(input[i][o + 1].ToString());
                return location;

            }
            ////First char first row
            //if (o == 0 && i == 0)
            //{

            //    location.down = int.Parse(input[i + 1][o].ToString());
            //    location.right = int.Parse(input[i][o + 1].ToString());
            //    location.CheckForLowPoint();
            //    return location;

            //}

            //First char of all rows except first and last
            if (o == 0 && i > 0 && i < input.Count - 1)
            {
                location.up = int.Parse(input[i - 1][o].ToString());
                location.down = int.Parse(input[i + 1][o].ToString());
                location.right = int.Parse(input[i][o + 1].ToString());

                return location;
            }

            ////Last char first row
            //if (o == input[0].Length && i == 0)
            //{

            //    location.down = int.Parse(input[i + 1][o].ToString());
            //    location.left = int.Parse(input[i][o - 1].ToString());

            //    location.CheckForLowPoint();
            //    return location;
            //}


            if (i == input.Count - 1)
            {
                if (o == 0)
                {

                    location.up = int.Parse(input[i - 1][o].ToString());
                    location.right = int.Parse(input[i][o + 1].ToString());
                    return location;
                }

                if (o == input[0].Length - 1)
                {
                    location.up = int.Parse(input[i - 1][o].ToString());
                    location.left = int.Parse(input[i][o - 1].ToString());
                    return location;
                }

                location.up = int.Parse(input[i - 1][o].ToString());
                location.left = int.Parse(input[i][o - 1].ToString());
                location.right = int.Parse(input[i][o + 1].ToString());
                return location;
            }
            ////First char last row
            //if (o == 0 && i == input.Count-1)
            //{
            //    location.up = int.Parse(input[i - 1][o].ToString());
            //    location.right = int.Parse(input[i][o + 1].ToString());
            //    location.CheckForLowPoint();
            //    return location;
            //}

            ////Last char last row
            //if (o == input[0].Length && i == input.Count)
            //{
            //    location.up = int.Parse(input[i - 1][o].ToString());
            //    location.left = int.Parse(input[i][o - 1].ToString());
            //    location.CheckForLowPoint();
            //    return location;
            //}

            //First char
            if (o == 0)
            {
                location.up = int.Parse(input[i - 1][o].ToString());
                location.down = int.Parse(input[i + 1][o].ToString());
                location.right = int.Parse(input[i][o + 1].ToString());
                return location;

            }

            //Last char
            if (o == input[0].Length - 1)
            {
                location.up = int.Parse(input[i - 1][o].ToString());
                location.down = int.Parse(input[i + 1][o].ToString());
                location.left = int.Parse(input[i][o - 1].ToString());
                return location;

            }

            //All other chars
            location.up = int.Parse(input[i - 1][o].ToString());
            location.down = int.Parse(input[i + 1][o].ToString());
            location.left = int.Parse(input[i][o - 1].ToString());
            location.right = int.Parse(input[i][o + 1].ToString());

            return location;
        }

        public static void SolvePartTwo()
        {
            List<int> basins = new List<int>();
            locations = new List<Location>();
            for (int i = 0; i < input.Count; i++)
            {
                for (int o = 0; o < input[0].Length; o++)
                {
                    Location location = GetLocationDetails(i, o);
                    location.i = i;
                    location.o = o;
                    location.CheckForLowPoint();
                    locations.Add(location);

                }

            }

            foreach (Location location in locations.Where(x => x.isLowPoint == true))
            {

                basins.Add(BasinCalculator(location, 1));
                
            }

            basins = basins.OrderByDescending(x => x).ToList();
            Utilities.Instance.OutputAnswer(9, (basins[0] * basins[1] * basins[2]).ToString());
        }

        private static int BasinCalculator(Location location, int basinSize)
        {
            int basinSizeSum = basinSize;
            if (location.alreadyInBasin == false)
            {
                if (location.height != 9)
                {

                    if (location.up > location.height && location.up != 99 && location.up != 9)
                    {
                        basinSizeSum += BasinCalculator(locations.Where(x => x.i == location.i - 1 && x.o == location.o).FirstOrDefault(), 1);
                    }
                    if (location.down > location.height && location.down != 99 && location.down != 9)
                    {
                        basinSizeSum += BasinCalculator(locations.Where(x => x.i == location.i + 1 && x.o == location.o).FirstOrDefault(), 1);
                    }
                    if (location.left > location.height && location.left != 99 && location.left != 9)
                    {
                        basinSizeSum += BasinCalculator(locations.Where(x => x.i == location.i && x.o == location.o - 1).FirstOrDefault(), 1);
                    }
                    if (location.right > location.height && location.right != 99 && location.right != 9)
                    {
                        basinSizeSum += BasinCalculator(locations.Where(x => x.i == location.i && x.o == location.o + 1).FirstOrDefault(), 1);
                    }
                }
            }
            else
            {
                return 0;
            }


            location.alreadyInBasin = true;
            return basinSizeSum;
        }
    }
}

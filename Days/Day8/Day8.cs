using AoC2021.HelperClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AoC2021.Days
{
    class Day8
    {
        private static List<string> input;
        static Day8()
        {
            input = Utilities.Instance.GetInput(nameof(Day8));
        }


        public static void SolvePartOne()
        {
            List<string> strings = new List<string>();

            foreach (string item in input)
            {
                foreach (string newItem in item.Split('|')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries))
                {
                    strings.Add(newItem);
                }
                ;
            }

            //List<string> digits = new List<string>(){"fdgacbe","gcbe","cgb","dgebacf","gc","cg","cg","cbg","cb","gecf","egdcabf","bgf","gebdcfa","ecba","ca","fadegcb","cefg","fcge","gbcadfe","ed","gbdfcae","bgc","cg","cgb","fgae","fg"};
            //Really need to learn how to read the puzzle

            Utilities.Instance.OutputAnswer(8, strings.Where(x => x.Length == 2 || x.Length == 3 || x.Length == 4 || x.Length == 7).Count().ToString());

        }

        public static void SolvePartTwo()
        {
            List<List<string>> signal = new List<List<string>>();
            List<List<string>> output = new List<List<string>>();
            int total = 0;
            string finalOutput = "";

            foreach (string item in input)
            {
                signal.Add(item.Split('|', StringSplitOptions.RemoveEmptyEntries)[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList());
                output.Add(item.Split('|', StringSplitOptions.RemoveEmptyEntries)[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList());
            }

            for (int i = 0; i < signal.Count(); i++)
            {
                string digitOne = signal[i].Single(x => x.Length == 2);
                string digitFour = signal[i].Single(x => x.Length == 4);
                string digitSeven = signal[i].Single(x => x.Length == 3);
                string digitEight = signal[i].Single(x => x.Length == 7);
                
                List<string> lengthFiveDigits = signal[i].Where(x => x.Length == 5).ToList();
                
                List<string> lengthSixDigits = signal[i].Where(x => x.Length == 6).ToList();

                string digitThree = lengthFiveDigits.Single(x => digitOne.All(x.Contains));
                lengthFiveDigits.Remove(digitThree);
                
                string digitNine = lengthSixDigits.Single(x => digitThree.All(x.Contains));
                lengthSixDigits.Remove(digitNine);

                string digitZero = lengthSixDigits.Single(x => digitOne.All(x.Contains));
                lengthSixDigits.Remove(digitZero);
                string digitSix = lengthSixDigits.Single();

                string digitFive = lengthFiveDigits.Single(x => x.All(digitSix.Contains));
                lengthFiveDigits.Remove(digitFive);
                string digitTwo = lengthFiveDigits.Single();

                List<string> numbers = new List<string>
                {
                    string.Join(string.Empty, digitZero.OrderBy(x => x)),
                    string.Join(string.Empty, digitOne.OrderBy(x => x)),
                    string.Join(string.Empty, digitTwo.OrderBy(x => x)),
                    string.Join(string.Empty, digitThree.OrderBy(x => x)),
                    string.Join(string.Empty, digitFour.OrderBy(x => x)),
                    string.Join(string.Empty, digitFive.OrderBy(x => x)),
                    string.Join(string.Empty, digitSix.OrderBy(x => x)),
                    string.Join(string.Empty, digitSeven.OrderBy(x => x)),
                    string.Join(string.Empty, digitEight.OrderBy(x => x)),
                    string.Join(string.Empty, digitNine.OrderBy(x => x))
                };


                finalOutput = "";
                for (int o = 0; o < output[i].Count(); o++)
                {
                    var n = string.Join("", output[i][o].OrderBy(x => x));

                    finalOutput += numbers.IndexOf(n);
                }


                total += int.Parse(finalOutput);
            }
            Utilities.Instance.OutputAnswer(8, total.ToString());

        }
    }

}

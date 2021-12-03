using AoC2021.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2021.Days
{
    class Day3
    {
        private static List<string> input;
        static Day3()
        {
            input = Utilities.Instance.GetInput(nameof(Day3));
        }


        public static void SolvePartOne()
        {
            int one = 0;
            int zero = 0;
            string gammaRate = "";
            string epsilonRate = "";
            long output = 0;
            //foreach (string inputString in input)
            //{
            //    foreach (char stringChar in inputString)
            //    {
            //        if (stringChar == '0')
            //        {
            //            zero++;
            //        }
            //        else
            //        {
            //            one++;
            //        }
            //    }

            //    if (zero > one)
            //    {
            //        gammaRate += "0";
            //        epsilonRate += "1";
            //    }
            //    else
            //    {
            //        gammaRate += "1";
            //        epsilonRate += "0";
            //    }
            //}

            //output = Convert.ToInt64(gammaRate.Substring(0,12), 2) * Convert.ToInt64(epsilonRate.Substring(0,12), 2);
            //Stupid, but fun. Learn to read......

            for (int i = 0; i < 12; i++)
            {
                for (int o = 0; o < input.Count; o++)
                {
                    if (input[o][i] == '0')
                    {
                        zero++;
                    }
                    else
                    {
                        one++;
                    }
                }
                if (zero > one)
                {
                    gammaRate += "0";
                    epsilonRate += "1";
                }
                else
                {
                    gammaRate += "1";
                    epsilonRate += "0";
                }
                zero = 0;
                one = 0;
            }

            Utilities.Instance.OutputAnswer(3, (Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2)).ToString());

        }

        public static void SolvePartTwo()
        {
            List<string> oxygenStrings = new List<string>(input);
            List<string> c02Strings = new List<string>(input);

            for (int i = 0; i < 12; i++)
            {
                if (oxygenStrings.Count != 1)
                {
                    int countOnes = oxygenStrings.Count(x => x[i] == '1');
                    
                    if (countOnes >= oxygenStrings.Count * 0.5)
                    {
                        oxygenStrings.RemoveAll(x => x[i] == '0');
                    }
                    else
                    {
                        oxygenStrings.RemoveAll(x => x[i] == '1');
                    }
                }
            }


            for (int i = 0; i < 12; i++)
            {
                if (c02Strings.Count != 1)
                {
                    int countZeroes = c02Strings.Count(x => x[i] == '0');

                    if (countZeroes <= c02Strings.Count * 0.5)
                    {
                        c02Strings.RemoveAll(x => x[i] == '1');
                    }
                    else
                    {
                        c02Strings.RemoveAll(x => x[i] == '0');
                    }
                }
            }

            Utilities.Instance.OutputAnswer(3, (Convert.ToInt32(oxygenStrings.FirstOrDefault(), 2) * Convert.ToInt32(c02Strings.FirstOrDefault(), 2)).ToString());

        }
    }
}

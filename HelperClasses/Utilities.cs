using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AoC2021.HelperClasses
{
    class Utilities
    {
        private static readonly Utilities instance = new Utilities();
        static Utilities()
        {
        }
        private Utilities()
        {
        }
        public static Utilities Instance => instance;

        public List<string> GetInput(object callingClass)
        {
            Console.WriteLine(callingClass);
            return File.ReadAllLines(@"..\..\..\Days\" + callingClass + @"\" + callingClass + @"input.txt").ToList<string>();
        }

        public void OutputAnswer(int dayNumber, string answer)
        {
            StackTrace trace = new StackTrace();
            string callingMethod = trace.GetFrame(1).GetMethod().Name;
            if (callingMethod.ToLower().Contains("one"))
            {
                Console.WriteLine("Day " + dayNumber + " part one answer: " + answer);
            }
            else
            {
                Console.WriteLine("Day " + dayNumber + " part two answer: " + answer);
            }
        }
    }
}

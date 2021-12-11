using AoC2021.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2021.Days
{
    class Day10
    {
        private static List<string> input;
        static Day10()
        {
            input = Utilities.Instance.GetInput(nameof(Day10));
        }


        public static void SolvePartOne()
        {

            long points = 0;
            foreach (var l in input)
            {
                Stack<char> stack = new();
                bool badFound = false;
                for (int i = 0; i < l.Length; i++)
                {
                    char cur = l[i];

                    switch (cur)
                    {
                        case '(':
                        case '[':
                        case '<':
                        case '{':
                            stack.Push(cur);
                            break;
                        case ')':
                            if (stack.Peek() == '(')
                            {
                                stack.Pop();
                            }
                            else
                            {
                                points += 3;
                                badFound = true;
                            }

                            break;
                        case ']':
                            if (stack.Peek() == '[')
                            {
                                stack.Pop();
                            }

                            else
                            {
                                points += 57;
                                badFound = true;
                            }
                            break;
                        case '}':
                            if (stack.Peek() == '{')
                            {
                                stack.Pop();
                            }
                            else
                            {
                                points += 1197;
                                badFound = true;
                            }
                            break;
                        case '>':
                            if (stack.Peek() == '<')
                            {
                                stack.Pop();
                            }
                            else
                            {
                                points += 25137;
                                badFound = true;
                            }
                            break;
                    }

                    if (badFound)
                    {
                        break;
                    }

                }
            }

            Utilities.Instance.OutputAnswer(10, points.ToString());
            

        }



        public static void SolvePartTwo()
        {
            //long points = 0;
            List<long> points = new List<long>();
            foreach (var l in input)
            {
                Stack<char> stack = new();
                bool badFound = false;
                for (int i = 0; i < l.Length; i++)
                {
                    char cur = l[i];

                    switch (cur)
                    {
                        case '(':
                        case '[':
                        case '<':
                        case '{':
                            stack.Push(cur);
                            break;
                        case ')':
                            if (stack.Peek() == '(')
                            {
                                stack.Pop();
                            }
                            else
                            {
                                //points += 3;
                                badFound = true;
                            }

                            break;
                        case ']':
                            if (stack.Peek() == '[')
                            {
                                stack.Pop();
                            }

                            else
                            {
                                //points += 57;
                                badFound = true;
                            }
                            break;
                        case '}':
                            if (stack.Peek() == '{')
                            {
                                stack.Pop();
                            }
                            else
                            {
                                //points += 1197;
                                badFound = true;
                            }
                            break;
                        case '>':
                            if (stack.Peek() == '<')
                            {
                                stack.Pop();
                            }
                            else
                            {
                                //points += 25137;
                                badFound = true;
                            }

                            break;

                    }
                    if (badFound) break;
                }

                if (!badFound)
                {
                    long point = 0;
                    while (stack.Count > 0)
                    {
                        point *= 5;
                        point += (stack.Pop()) switch
                        {
                            '(' => 1,
                            '[' => 2,
                            '{' => 3,
                            '<' => 4,
                            _ => 0
                        };
                    }
                    points.Add(point);
                }
            }
            List<long> sorted = points.OrderBy(x => x).ToList();
            Utilities.Instance.OutputAnswer(10, sorted.Skip(sorted.Count / 2).Take(1).First().ToString());
        }
    }
}

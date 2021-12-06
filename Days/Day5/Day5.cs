using AoC2021.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Days
{
    class Day5
    {
        private static List<string> input;
        static Day5()
        {
            input = Utilities.Instance.GetInput(nameof(Day5));
        }


        public static void SolvePartOne()
        {
            List<Line> lines = new List<Line>();
            List<Point> allPoints = new List<Point>();
            foreach (string item in input)
            {
                List<string> splittedString = item.Split("->").ToList();
                Line line = new Line();
                line.x1 = int.Parse(splittedString[0].Trim().Split(",")[0]);
                line.x2 = int.Parse(splittedString[1].Trim().Split(",")[0]);
                line.y1 = int.Parse(splittedString[0].Trim().Split(",")[1]);
                line.y2 = int.Parse(splittedString[1].Trim().Split(",")[1]);
                if (line.x1 == line.x2 || line.y1 == line.y2)
                {
                    lines.Add(line);
                    if (line.x1 == line.x2)
                    {
                        Point point = new Point();
                        for (int i = 0; i < Math.Abs(line.y1 - line.y2) + 1; i++)
                        {
                            point = new Point();
                            point.x = line.x1;
                            if (line.y1 > line.y2)
                            {
                                point.y = i + line.y2;
                            }
                            else
                            {
                                point.y = i + line.y1;
                            }

                            allPoints.Add(point);
                        }
                    }
                    else
                    {
                        Point point = new Point();
                        for (int i = 0; i < Math.Abs(line.x1 - line.x2) + 1; i++)
                        {
                            point = new Point();
                            if (line.x1 > line.x2)
                            {
                                point.x = i + line.x2;
                            }
                            else
                            {
                                point.x = i + line.x1;
                            }
                            point.y = line.y1;
                            allPoints.Add(point);
                        }
                    }
                }
            }

            Utilities.Instance.OutputAnswer(5, allPoints.GroupBy(x => new { x.x, x.y }).Where(z => z.Count() >= 2).Count().ToString());
        }

        public static void SolvePartTwo()
        {

            List<Line> lines = new List<Line>();
            List<Point> allPoints = new List<Point>();
            foreach (string item in input)
            {
                List<string> splittedString = item.Split("->").ToList();
                Line line = new Line();
                line.x1 = int.Parse(splittedString[0].Trim().Split(",")[0]);
                line.x2 = int.Parse(splittedString[1].Trim().Split(",")[0]);
                line.y1 = int.Parse(splittedString[0].Trim().Split(",")[1]);
                line.y2 = int.Parse(splittedString[1].Trim().Split(",")[1]);
                if (line.x1 == line.x2 || line.y1 == line.y2)
                {
                    lines.Add(line);
                    if (line.x1 == line.x2)
                    {
                        Point point = new Point();
                        for (int i = 0; i < Math.Abs(line.y1 - line.y2) + 1; i++)
                        {
                            point = new Point();
                            point.x = line.x1;
                            if (line.y1 > line.y2)
                            {
                                point.y = i + line.y2;
                            }
                            else
                            {
                                point.y = i + line.y1;
                            }

                            allPoints.Add(point);
                        }
                    }
                    else
                    {
                        Point point = new Point();
                        for (int i = 0; i < Math.Abs(line.x1 - line.x2) + 1; i++)
                        {
                            point = new Point();
                            if (line.x1 > line.x2)
                            {
                                point.x = i + line.x2;
                            }
                            else
                            {
                                point.x = i + line.x1;
                            }
                            point.y = line.y1;
                            allPoints.Add(point);
                        }
                    }
                }
                else
                {
                    Point point = new Point();
                    for (int i = 0; i < Math.Abs(line.y1 - line.y2) + 1; i++)
                    {
                        point = new Point();
                        if (line.x1 > line.x2)
                        {
                            point.x = line.x1 - i;
                        }
                        else
                        {
                            point.x = line.x1 + i;
                        }

                        if (line.y1 > line.y2)
                        {
                            point.y = line.y1 - i;
                        }
                        else
                        {
                            point.y = line.y1 + i;
                        }

                        allPoints.Add(point);
                    }
                }
            }

            Utilities.Instance.OutputAnswer(5, allPoints.GroupBy(x => new { x.x, x.y }).Where(z => z.Count() >= 2).Count().ToString());
        }
    }
}

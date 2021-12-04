using AoC2021.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2021.Days
{
    class Day4
    {
        private static List<string> input;
        static Day4()
        {
            input = Utilities.Instance.GetInput(nameof(Day4));
        }


        public static void SolvePartOne()
        {
            List<int> numbersToDraw = input[0]?.Split(',').Select(int.Parse).ToList();
            List<BingoBoard> boards = new List<BingoBoard>();
            BingoBoard board = new BingoBoard();
            //int columnCount = 0;

            for (int i = 1; i < input.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(input[i]))
                {
                    if (board.Columns.Count != 0)
                    {
                        boards.Add(board);
                    }

                    board = new BingoBoard();
                    board.Columns.Add(new List<int>());
                    board.Columns.Add(new List<int>());
                    board.Columns.Add(new List<int>());
                    board.Columns.Add(new List<int>());
                    board.Columns.Add(new List<int>());
                    //columnCount = 0;

                }
                else
                {
                    List<string> test = new List<string>(input[i]?.Split(' '));
                    List<int> newList = new List<int>(input[i]?.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
                    board.Rows.Add(newList);
                    board.Columns[0].Add(newList[0]);
                    board.Columns[1].Add(newList[1]);
                    board.Columns[2].Add(newList[2]);
                    board.Columns[3].Add(newList[3]);
                    board.Columns[4].Add(newList[4]);

                }
            }

            foreach (int item in numbersToDraw)
            {
                Console.WriteLine("Running " + item);
                foreach (BingoBoard bingoBoard in boards)
                {
                    bingoBoard.RemoveNumberAndCheckForBingo(item);
                }
            }

        }

        public static void SolvePartTwo()
        {
            List<int> numbersToDraw = input[0]?.Split(',').Select(int.Parse).ToList();
            List<BingoBoard> boards = new List<BingoBoard>();
            BingoBoard board = new BingoBoard();
            //int columnCount = 0;

            for (int i = 1; i < input.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(input[i]))
                {
                    if (board.Columns.Count != 0)
                    {
                        boards.Add(board);
                    }

                    board = new BingoBoard();
                    board.Columns.Add(new List<int>());
                    board.Columns.Add(new List<int>());
                    board.Columns.Add(new List<int>());
                    board.Columns.Add(new List<int>());
                    board.Columns.Add(new List<int>());
                    //columnCount = 0;

                }
                else
                {
                    List<string> test = new List<string>(input[i]?.Split(' '));
                    List<int> newList = new List<int>(input[i]?.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
                    board.Rows.Add(newList);
                    board.Columns[0].Add(newList[0]);
                    board.Columns[1].Add(newList[1]);
                    board.Columns[2].Add(newList[2]);
                    board.Columns[3].Add(newList[3]);
                    board.Columns[4].Add(newList[4]);

                }
            }

            foreach (int item in numbersToDraw)
            {
                BingoBoard previousBoard = null;
                //int previousNumber = 
                Console.WriteLine("Running " + item);
                for (int i = 0; i < boards.Count; i++)
                {
                    previousBoard = boards[i].RemoveNumberAndCheckForBingoAndRemoveBoard(item);
                    boards.Remove(previousBoard);
                }
                if (boards.Count == 1)
                {
                    previousBoard.RemoveNumberAndCheckForBingoAndRemoveBoard(item, 1);
                }
                //foreach (BingoBoard bingoBoard in boards)
                //{
                //    bingoBoard.RemoveNumberAndCheckForBingoAndRemoveBoard(item);
                //}
            }
        }
    }
}

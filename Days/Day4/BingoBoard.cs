using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2021.Days
{
    class BingoBoard
    {
        List<List<int>> rows = new List<List<int>>();
        List<List<int>> columns = new List<List<int>>();

        public List<List<int>> Rows { get => rows; set => rows = value; }
        public List<List<int>> Columns { get => columns; set => columns = value; }

        public void RemoveNumberAndCheckForBingo(int number)
        {
            //Do LINQ later
            foreach (List<int> row in this.rows)
            {
                row.RemoveAll(x => x == number);
                if (!row.Any())
                {
                    CreateFinalScore(number);
                }
            }

            foreach (List<int> column in this.Columns)
            {
                column.RemoveAll(x => x == number);
                if (!column.Any())
                {
                    CreateFinalScore(number);
                }
            }
        }

        public BingoBoard RemoveNumberAndCheckForBingoAndRemoveBoard(int number, int lastBoard = 0)
        {
            if (lastBoard == 1)
            {
                CreateFinalScore(number);
                return this;
            }
            //Do LINQ later
            foreach (List<int> row in this.rows)
            {
                row.RemoveAll(x => x == number);
                if (!row.Any())
                {
                    return this;
                    //CreateFinalScore(number);
                }
            }

            foreach (List<int> column in this.Columns)
            {
                column.RemoveAll(x => x == number);
                if (!column.Any())
                {
                    return this;
                    //CreateFinalScore(number);
                }

            }

            if (lastBoard == 1)
            {
                CreateFinalScore(number);
            }

            return null;
        }

        private void CreateFinalScore(int number)
        {
            int sum = 0;
            foreach (List<int> item in rows)
            {
                sum += item.Sum();
            }
            int finalSum = rows.SelectMany(x => x).Sum();

            Console.WriteLine(finalSum * number);
        }
    }
}

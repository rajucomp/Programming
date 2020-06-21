using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CodeForecs.Topics.Graph.Breadth_First_Search
{
    //https://leetcode.com/problems/rotting-oranges/
    class Rotting_Oranges
    {
        public enum OrangeType
        {
            Fresh = 1,
            Rotten = 2
        }

        private bool IsValidIndex(int i, int j, int rows, int cols, int[][] grid)
        {
            return i >= 0 && i < rows && j >= 0 && j < cols && grid[i][j] == (int)OrangeType.Fresh;
        }
        public int OrangesRotting(int[][] grid)
        {
            int rows = grid.Length, cols = grid[0].Length;

            Queue<int[]> queue = new Queue<int[]>();

            int countOfFreshOranges = 0, countMinutes = 0;

            int[,] directionalArray = new int[4, 2]
            {
                {0, 1},
                {0, -1},
                {1, 0},
                {-1, 0}
            };

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == (int)OrangeType.Rotten)
                    {
                        queue.Enqueue(new int[] { i, j });
                    }
                    else if (grid[i][j] == (int)OrangeType.Fresh)
                    {
                        countOfFreshOranges++;
                    }
                }
            }

            while (queue.Count != 0 && countOfFreshOranges > 0)
            {
                countMinutes++;

                int size = queue.Count;

                while (size-- != 0)
                {
                    var orange = queue.Dequeue();

                    for (int i = 0; i < directionalArray.GetLength(0); i++)
                    {
                        int x = orange[0] + directionalArray[i, 0];

                        int y = orange[1] + directionalArray[i, 1];

                        if (IsValidIndex(x, y, rows, cols, grid))
                        {
                            queue.Enqueue(new int[] { x, y });
                            grid[x][y] = (int)OrangeType.Rotten;
                            countOfFreshOranges--;
                        }
                    }
                }

            }
            return countOfFreshOranges == 0 ? countMinutes : -1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs._30DayLeetCodingChallenge.Week_3
{
    //https://leetcode.com/problems/number-of-islands/
    class NumberOfIslands
    {
        public void Traverse(char[][] grid, bool[][] visited, int i, int j)
        {
            //If the indexes are out of range, we do not process them.
            if (i < 0 || i >= visited.Length || j < 0 || j >= visited[0].Length)
            {
                return;
            }

            if (!visited[i][j] && grid[i][j] == '1')
            {
                visited[i][j] = true;
                Traverse(grid, visited, i, j + 1); //Traverse right horizontally
                Traverse(grid, visited, i, j - 1); //Traverse left horizontally
                Traverse(grid, visited, i - 1, j); //Traverse up vertically
                Traverse(grid, visited, i + 1, j); //Traverse down vertically
            }
        }
        public int NumIslands(char[][] grid)
        {
            //a boolean array to mark the visited cells so we don't revisit them.
            bool[][] visited = new bool[grid.Length][];

            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = new bool[grid[0].Length];
            }

            int numberOfConnectedComponents = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (!visited[i][j] && grid[i][j] == '1')
                    {
                        Traverse(grid, visited, i, j);
                        numberOfConnectedComponents++;
                    }
                }
            }

            return numberOfConnectedComponents;
        }
    }
}

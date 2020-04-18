using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs._30DayLeetCodingChallenge.Week_3
{
    //https://leetcode.com/problems/minimum-path-sum/
    class MinimumPathSum
    {
        //2D DP Solution with O(n^2) Time and O(n^2) space
        public int MinPathSum(int[][] grid)
        {
            int[,] dpArray = new int[grid.Length,grid[0].Length];

            int rows = dpArray.GetLength(0);
            int columns = dpArray.GetLength(1);

            dpArray[0,0] = grid[0][0];

            //Set the values for the first row.
            for(int i = 1; i < columns; i++)
            {
                dpArray[0,i] = (grid[0][i] + dpArray[0,i-1]);
            }

            //Set the values for the first column.
            for(int j = 1; j < rows; j++)
            {
                dpArray[j,0] = (grid[j][0] + dpArray[j-1,0]);
            }

            //Set the values for the rest of the cells
            for(int i = 1; i < rows; i++)
            {
                for(int j = 1; j < columns; j++)
                {
                    dpArray[i,j] = Math.Min(dpArray[i-1,j], dpArray[i,j-1]) + grid[i][j];
                }
            }

            return dpArray[rows-1,columns-1];
        }
    
        //1D DP Solution with O(n^2) Time and O(n) space
        public int AnotherMinPathSum(int[][] grid)
        {
            int rows = grid.Length;
            int columns = grid[0].Length;

            int[] dpArray = new int[columns];
        
            dpArray[0] = grid[0][0];
        
            for(int i = 1; i < columns; i++)
            {
                dpArray[i] = grid[0][i] + dpArray[i-1];
            }

            for(int i = 1; i < rows; i++)
            {
                dpArray[0] += grid[i][0];
                for(int j = 1; j < columns; j++)
                {
                    dpArray[j] = Math.Min(dpArray[j], dpArray[j-1]) + grid[i][j];
                }
            }

            return dpArray[columns-1];
        }
    
        //This case only applies if we are allowed to change the contents of the input array.
        //2D DP Solution with O(n^2) Time and O(1) space
        public int FastestMinPathSum(int[][] grid)
        {
            int rows = grid.Length;
            int columns = grid[0].Length;

            for(int i = 1; i < columns; i++)
            {
                grid[0][i] += grid[0][i-1];
            }

            for(int j = 1; j < rows; j++)
            {
                grid[j][0] += grid[j-1][0];
            }

            for(int i = 1; i < rows; i++)
            {
                for(int j = 1; j < columns; j++)
                {
                    grid[i][j] += Math.Min(grid[i-1][j], grid[i][j-1]);
                }
            }

            return grid[rows-1][columns-1];
        }
    }

}

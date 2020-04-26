using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CodeForecs._30DayLeetCodingChallenge.Week_4
{
    //https://leetcode.com/problems/longest-common-subsequence
    class LongestCommonSubsequence
    {
        public static void TestSolution()
        {
            //Input string generated from https://onlinerandomtools.com/generate-random-string
            string[] input = File.ReadAllTextAsync(@"C:\Users\guptraju\source\repos\CodeForecs\InputFiles\LCSInput.txt").Result.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            string text1 = input[0];
            string text2 = input[1];

            //string text1 = "abde", text2 = "aec";

            LongestCommonSubsequence testObject = new LongestCommonSubsequence();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int result = testObject.LCS(text1, text2);

            stopwatch.Stop();

            Console.WriteLine("The general method returned the value " + result + " and took " + stopwatch.Elapsed.TotalSeconds + " seconds.");

            stopwatch.Reset();

            stopwatch.Start();

            result = testObject.LCSSpaceOptimised(text1, text2);

            stopwatch.Stop();

            Console.WriteLine("The space optimised method returned the value " + result + " and took " + stopwatch.Elapsed.TotalSeconds + " seconds.");
        }
        //2D DP Solution with O(text1.Length * text2.Length) Time and O(text1.Length * text2.Length) space.
        public int LCS(string text1, string text2)
        {
            int[,] dp = new int[text1.Length + 1, text2.Length + 1];

            for(int i = 0; i < text1.Length; i++)
            {
                for(int j = 0; j < text2.Length; j++)
                {
                    if(text1[i].Equals(text2[j]))
                    {
                        dp[i + 1, j + 1] = 1 + dp[i, j];
                    }
                    else
                    {
                        dp[i + 1, j + 1] = Math.Max(dp[i, j + 1], dp[i + 1, j]);
                    }
                }
            }

            return dp[text1.Length, text2.Length];
        }

        //2D DP Solution with O(text1.Length * text2.Length) Time and O(Math.Min(text1.Length, text2.Length)) space.
        public int LCSSpaceOptimised(string text1, string text2)
        {
            if(text1.Length <= text2.Length)
            {
                return LCSSpaceOptimised(text1, text2, text1.Length + 1);
            }

            return LCSSpaceOptimised(text2, text1, text2.Length + 1);
            
        }

        //Here A is the string with length less than or equal to B.
        public int LCSSpaceOptimised(string A, string B, int sizeOfDpArray)
        {
            //Console.WriteLine(A + " " + B);

            //Will hold the current values of the dp array.
            int[] currentDp = new int[sizeOfDpArray];

            for (int i = 1; i <= B.Length; i++)
            {
                int previous = 0;
                for (int j = 1; j <= A.Length; j++)
                {
                    int oldValue = currentDp[j];

                    //Console.WriteLine(B[i] + " " + A[j]);
                    if (B[i-1].Equals(A[j-1]))
                    {
                        currentDp[j] = 1 + previous;
                    }
                    else
                    {
                        currentDp[j] = Math.Max(currentDp[j], currentDp[j-1]);
                    }

                    previous = oldValue;
                }

                /*
                for (int j = 1; j < currentDp.Length; j++)
                {
                    Console.Write(currentDp[j] + " ");
                }
                Console.WriteLine();
                */
            }

            return currentDp[sizeOfDpArray - 1];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CodeForecs
{
    class Program
    {
        static void Main(string[] args)
        {
            //string num = Console.ReadLine();
            //int res = MakeSquare(num, 0);
            //Console.WriteLine(res == 1000 ? -1 : res);
            //Console.ReadKey();

            //int[][] nums = new int[3][];
            //nums[0] = new int[] { 3, 3 };
            //nums[1] = new int[] { 5, -1 };
            //nums[2] = new int[] { -2, 4 };
            //int k = 2;

            //var obj = new _973KClosestPointsToOrigin();

            //var answer = obj.KClosest(nums, k);

            //NumberOfStepsToReduceANumberInBinaryRepresentationToOne.Solution();

            int[] arr = new int[] { 2, 7, 4, 8, 1, 1, };

            Console.WriteLine(new LastStoneWeightSolution().LastStoneWeight(arr));

        }

        private static int MakeSquare(string str, int digit)
        {
            if (NoLeadingZeros(str) && IsASquare(Convert.ToInt32(str)))
            {
                return digit;
            }

            List<string> lst = new List<string>();

            for (int i = 0; i < str.Length; i++)
            {
                string temp = str.Remove(i, 1);
                if (temp.Length != 0)
                    lst.Add(temp);
            }

            int ans = 1000;
            foreach (string temp in lst)
            {
                ans = Math.Min(ans, MakeSquare(temp, digit + 1));
            }

            return ans;
        }

        private static bool NoLeadingZeros(string str)
        {
            return str[0] != '0';
        }

        private static bool IsASquare(int num)
        {
            for (int i = 1; i * i <= num; i++)
            {
                if (i * i == num)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

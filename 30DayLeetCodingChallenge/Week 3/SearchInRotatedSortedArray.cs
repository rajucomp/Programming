using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeForecs._30DayLeetCodingChallenge.Week_3
{
    //https://leetcode.com/problems/search-in-rotated-sorted-array/
    class SearchInRotatedSortedArray
    {
        public static void TestSolution()
        {
            int[] array = File.ReadAllLinesAsync(@"C:\Users\guptraju\source\repos\CodeForecs\InputFiles\OneLakhSortedIntegers.txt").Result[0].Split(',').Select(x => Int32.Parse(x)).ToArray();

            SearchInRotatedSortedArray testObject = new SearchInRotatedSortedArray();

            int target = new Random().Next(0, 99999);

            Console.WriteLine("The target to be searched is " + target);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            int result = testObject.Search(array, target);

            stopwatch.Stop();

            Console.WriteLine("Time taken using Iterative method :- " + stopwatch.Elapsed.TotalSeconds);

            stopwatch.Start();
            result = testObject.SearchRecursive(0, array.Length - 1, array, target);

            stopwatch.Stop();

            Console.WriteLine("Time taken using Recursive method :- " + stopwatch.Elapsed.TotalSeconds);
        }
        public int Search(int[] nums, int target)
        {
            int start = 0, end = nums.Length - 1;

            return Search(start, end, nums, target);
        }

        //Iterative solution
        public int Search(int start, int end, int[] nums, int target)
        {
            while (start <= end)
            {
                int mid = start + (end - start) / 2;

                if (target == nums[mid])
                {
                    return mid;
                }

                if (IsArraySorted(start, mid - 1, nums))
                {
                    if (ArrayContains(start, mid - 1, nums, target))
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
                else if (ArrayContains(mid + 1, end, nums, target))
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return -1;
        }

        //Recursive solution
        public int SearchRecursive(int start, int end, int[] nums, int target)
        {
            if (start <= end)
            {
                int mid = start + (end - start) / 2;

                if (target == nums[mid])
                {
                    return mid;
                }

                if (IsArraySorted(start, mid - 1, nums))
                {
                    if (ArrayContains(start, mid - 1, nums, target))
                    {
                        return Search(start, mid - 1, nums, target);
                    }
                    return Search(mid + 1, end, nums, target);
                }

                if (ArrayContains(mid + 1, end, nums, target))
                {
                    return Search(mid + 1, end, nums, target);
                }
                return Search(start, mid - 1, nums, target);
            }

            return -1;
        }

        public bool IsArraySorted(int start, int end, int[] nums)
        {
            return start <= end && nums[start] <= nums[end];
        }

        public bool ArrayContains(int start, int end, int[] nums, int target)
        {
            return start <= end && target >= nums[start] && target <= nums[end];
        }

    }
}

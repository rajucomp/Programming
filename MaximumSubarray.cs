using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs
{
    //https://leetcode.com/problems/maximum-subarray/
    class MaximumSubarray
    {
        public int MaxSubArray(int[] nums)
        {
            int maxSubArraySum = nums[0];

            int maxSubArraySumSoFar = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                //Console.WriteLine(i + " " + maxSubArraySum + " " + maxSubArraySumSoFar);
                maxSubArraySumSoFar = Math.Max(maxSubArraySumSoFar + nums[i], nums[i]);
                maxSubArraySum = Math.Max(maxSubArraySum, maxSubArraySumSoFar);

                //Console.WriteLine(nums[i] + " " + maxSubArraySum + " " + maxSubArraySumSoFar);
            }

            return maxSubArraySum;
        }
    }
}

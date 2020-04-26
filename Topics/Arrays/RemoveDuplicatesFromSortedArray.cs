using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs.Topics.Arrays
{
    //https://leetcode.com/problems/remove-duplicates-from-sorted-array/
    class RemoveDuplicatesFromSortedArray
    {
        public int RemoveDuplicates(int[] nums)
        {
            int countOfDuplicates = 0;

            for(int i = 1; i < nums.Length; i++)
            {
                if(nums[i] == nums[i-1])
                {
                    countOfDuplicates++;
                }
                else
                {
                    nums[i - countOfDuplicates] = nums[i];
                }
            }

            return nums.Length - countOfDuplicates;
        }
    }
}

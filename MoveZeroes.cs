using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs
{
    //https://leetcode.com/problems/move-zeroes/
    class MoveZeroes
    {
        public void MoveZeroess(int[] nums)
        {
            int indexZero = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[indexZero++] = nums[i];
                }
            }

            while (indexZero < nums.Length)
            {
                nums[indexZero++] = 0;
            }
        }
    }
}

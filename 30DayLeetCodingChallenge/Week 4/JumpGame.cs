using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs._30DayLeetCodingChallenge.Week_4
{
    //https://leetcode.com/problems/jump-game/
    class JumpGame
    {
        public static void TestSolution()
        {
            int[] testArray = new int[] { 2, 5, 0, 0 };

            JumpGame testObject = new JumpGame();

            Console.WriteLine(testObject.CanJump(testArray));

            Console.WriteLine(testObject.CanJumpOptimised(testArray));
        }

        //Greedy Solution
        public bool CanJump(int[] nums)
        {
            int position = nums[0];

            for(int i = 1; i < nums.Length; i++)
            {
                if(i <= position)
                {
                    position = Math.Max(i + nums[i], position);
                }
            }

            return position >= nums.Length - 1;
        }

        //Optimised Solution
        public bool CanJumpOptimised(int[] nums)
        {
            int position = nums[0];

            for(int i = 1; i < nums.Length; i++)
            {
                if(i <= position)
                {
                    position = Math.Max(i + nums[i], position);
                }
                //we cannot reach to the end of the array if the current index cannot be reached.
                else
                {
                    return false;
                }

                //No need to traverse through the rest of the array. We can reach the end of the array.
                if(position >= nums.Length - 1)
                {
                    break;
                }
            }

            return true;
        }
    }
}

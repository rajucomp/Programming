using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs.Topics.Arrays
{
    //https://leetcode.com/problems/remove-element/
    class RemoveElement
    {
        //A solution that does unnecessary assignments when the target element is rare.
        //Remember the order does not matter here.
        public int RemoveTargetElement(int[] nums, int val)
        {
            //Hold the total number of val in the array.
            int countOfTarget = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                //If we find the val, we increment the counter.
                if(nums[i] == val)
                {
                    countOfTarget++;
                }
                //Else we copy the current element to its updated position.
                else if(countOfTarget > 0)
                {
                    nums[i - countOfTarget] = nums[i];
                }
            }

            //The updated length will be difference between the old length of the array and 
            //the total number of val in the array.
            return nums.Length - countOfTarget;
        }

        //An optimised solution that does assignments equal to the number of elements equal to the target value.
        public int RemoveTargetElementOptimised(int[] nums, int val)
        {
            int i = 0;

            int size = nums.Length;

            while(i < size)
            {
                if(nums[i] == val)
                {
                    nums[i] = nums[size - 1];
                    size--;
                }
                else
                {
                    i++;
                }
            }

            return size;
        }
    }
}

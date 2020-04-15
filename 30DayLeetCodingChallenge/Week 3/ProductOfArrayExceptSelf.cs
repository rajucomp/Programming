using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs._30DayLeetCodingChallenge.Week_3
{
    //https://leetcode.com/problems/product-of-array-except-self/
    class ProductOfArrayExceptSelf
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] output = new int[nums.Length];

            int product = 1;

            int[] suffixArray = new int[nums.Length];

            int[] prefixArray = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                product *= nums[i];

                suffixArray[i] = product;
            }

            product = 1;

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                product *= nums[i];

                prefixArray[i] = product;
            }

            /*

            Console.Write("Suffix:- ");
            for(int i = 0; i < nums.Length; i++)
            {
                Console.Write(suffixArray[i] + " ");
            }

            Console.WriteLine();

            Console.Write("Prefix:- ");

            for(int i = 0; i < nums.Length; i++)
            {
                Console.Write(prefixArray[i] + " ");
            }

            */


            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    output[i] = prefixArray[i + 1];
                }
                else if (i == nums.Length - 1)
                {
                    output[i] = suffixArray[i - 1];
                }
                else
                {
                    output[i] = suffixArray[i - 1] * prefixArray[i + 1];
                }
            }

            return output;
        }
    }
}

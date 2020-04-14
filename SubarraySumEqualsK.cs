using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs
{
    class SubarraySumEqualsK
    {
        public int SubarraySum(int[] nums, int k)
        {
            IDictionary<int, int> dict = new Dictionary<int, int>();
            dict.Add(0, 1);

            int sum = 0;

            int count = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                if(dict.ContainsKey(sum - k))
                {
                    count += dict[sum - k];
                    dict.Add(sum, 1);
                }
                else
                {
                    dict.Add(sum - k, 1);
                }
                
            }

            return count;
        }
    }
}

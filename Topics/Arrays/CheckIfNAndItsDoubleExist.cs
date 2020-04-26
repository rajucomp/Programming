using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs.Topics.Arrays
{
    //https://leetcode.com/problems/check-if-n-and-its-double-exist/
    class CheckIfNAndItsDoubleExist
    {
        public bool CheckIfExist(int[] arr)
        {
            HashSet<int> hashSet = new HashSet<int>();

            foreach (int i in arr)
            {
                if (hashSet.Contains(2 * i) || ((i & 1) == 0 && hashSet.Contains(i / 2)))
                {
                    return true;
                }

                hashSet.Add(i);
            }

            return false;
        }
    }
}

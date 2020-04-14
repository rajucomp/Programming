using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeForecs
{
    public class CustomComparer : IComparer<CustomObject>
    {
        int IComparer<CustomObject>.Compare(CustomObject x, CustomObject y)
        {
            if(x.Value < y.Value)
            {
                y.NumbersSmaller += 1;
            }
            else if(x.Value > y.Value)
            {
                x.NumbersSmaller += 1;
            }

            return 0;
        }

    }

    public class CustomObject
    {
        public int Value { get; set; }

        public int Index { get; set; }

        public int NumbersSmaller { get; set; }

        public CustomObject(int x, int y)
        {
            Value = x;
            Index = y;
        }
    }
    public class _1365HowManyNumbersAreSmallerThantheCurrentNumber
    {
        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            //int size = nums.Length;
            //CustomObject[] arr = new CustomObject[size];

            //for(int i = 0; i < size; i++)
            //{
            //    arr[i] = new CustomObject(nums[i], i);
            //}

            //Array.Sort(arr, new CustomComparer());

            //int[] answer = new int[size];

            //var final = arr.Zip(answer, Tuple.Create);


            //foreach (var nw in arr.Zip(answer, Tuple.Create))
            //{
            //    nw.Item2 = nw.Item1.NumbersSmaller;                                         
            //}

            int size = nums.Length;

            int[] answer = new int[size];

            for(int i = 0; i < size; i++)
            {
                int total = 0;
                for(int j = 0; j < size; j++)
                {
                    if(nums[j] < nums[i])
                    {
                        total += 1;
                    }
                }
                answer[i] = total;
            }

            return answer;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs
{
    class ArrayObject : IComparable<ArrayObject>
    {
        public int NoOfBinaryDigits { get; set; }

        public int Value { get; set; }

        public ArrayObject(int digits, int value)
        {
            NoOfBinaryDigits = digits;
            Value = value;
        }
        public int CompareTo(ArrayObject other)
        {
            if (other == null)
                return -1;
            if (NoOfBinaryDigits == other.NoOfBinaryDigits)
                return Value.CompareTo(other.Value);
            return NoOfBinaryDigits.CompareTo(other.NoOfBinaryDigits);
        }
    }

    
    class SortIntegersByBits
    {

        public int SetBits(int n)
        {
            int count = 0;
            while (n > 0)
            {
                n &= (n - 1);
                count++;
            }
            return count;
        }
        public int[] SortByBits(int[] arr)
        {
            List<ArrayObject> lst = new List<ArrayObject>();
            foreach(int i in arr)
            {
                lst.Add(new ArrayObject(SetBits(i), i));
            }

            lst.Sort();

            int[] answer = new int[arr.Length];

            for(int i = 0; i < answer.Length; i++)
            {
                answer[i] = lst[i].Value;
            }

            return answer;
        }

    }
}

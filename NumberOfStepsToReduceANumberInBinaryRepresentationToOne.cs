using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;

namespace CodeForecs
{
    //https://leetcode.com/problems/number-of-steps-to-reduce-a-number-in-binary-representation-to-one/
    class NumberOfStepsToReduceANumberInBinaryRepresentationToOne
    {
        public static void Solution()
        {
            string str = File.ReadAllText(@"C:\Users\guptraju\source\repos\CodeForecs\InputFiles\NumberOfStepsToReduceANumberInBinaryRepresentationToOne.txt");

            Console.WriteLine(str.Length);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            //Console.WriteLine(new NumberOfStepsToReduceANumberInBinaryRepresentationToOne().NumSteps(str));
            watch.Stop();
            //Console.WriteLine(watch.Elapsed.TotalSeconds);

            watch.Reset();
            watch.Start();
            //Console.WriteLine(new NumberOfStepsToReduceANumberInBinaryRepresentationToOne().NumSteps1(str));
            watch.Stop();
            //Console.WriteLine(watch.Elapsed.TotalSeconds);


            watch.Reset();
            watch.Start();
            Console.WriteLine(new NumberOfStepsToReduceANumberInBinaryRepresentationToOne().NumSteps2(str));
            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalSeconds);
        }
        public int NumSteps(string s)
        {
            StringBuilder sb = new StringBuilder(s);

            return NumSteps(sb, sb.Length);
        }

        public int NumSteps(StringBuilder sb, int size)
        {
            //Console.WriteLine(sb.ToString().Substring(0, size));
            //Console.WriteLine(Convert.ToInt32(sb.ToString().Substring(0, size), 2).ToString());
            if (size == 1)
            {
                if (sb[size - 1] == '1')
                    return 0;
                return 1;
            }

            int steps = 0;
            while (size != 0 && sb[size - 1] == '0')
            {
                steps++;
                size--;
            }

            //Console.WriteLine(steps);
            size = AddOneToStringBuilder(sb, size) ? size + 1 : size;

            return size == 1 ? steps + NumSteps(sb, size) : 1 + steps + NumSteps(sb, size);
        }

        public bool AddOneToStringBuilder(StringBuilder sb, int size)
        {
            if (size == 1)
            {
                return false;
            }
            while (size >= 1)
            {
                if (sb[size - 1] == '1')
                {
                    sb[size - 1] = '0';
                    size--;
                }
                else
                {
                    sb[size - 1] = '1';
                    return false;
                }
            }

            if (size <= 0)
            {
                sb.Insert(0, '1');
            }
            return true;
        }

        //Alternate solution using BigInteger
        public int NumSteps1(string s)
        {
            //transform into an int

            if (s.Length == 0 || s == null)
                return 0;
             System.Numerics.BigInteger value = ConvertToBigInt(s);
            //check the first bit, add one if it is odd, divide by 2 if it is even
            int times = 0;
            while (value != 1)
            {
                if (value % 2 == 1)
                    value++;
                else if (value % 2 == 0)
                    value /= 2;
                times++;
            }
            return times;
        }
        private System.Numerics.BigInteger ConvertToBigInt(string s)
        {
            System.Numerics.BigInteger bi = 0;
            foreach (var c in s)
            {
                bi = bi * 2 + (c == '1' ? 1 : 0);
            }
            return bi;
        }

        //the fastest solution
        public int NumSteps2(string s)
        {
            int steps = 0;
            int carry = 0;

            for (int i = s.Length - 1; i > 0; i--)
            {
                if (s[i] - '0' + carry == 0)
                {
                    steps++;
                    carry = 0;
                }
                else if (s[i] - '0' + carry == 1)
                {
                    steps += 2;     // after adding 1 and / 2
                    carry = 1;    // example: 1 + 1 -> 10 -> 10 >> 1 -> carry 1 over
                }
                else
                {
                    steps++;          // current digit is 1, adding carry over 1 is 10 -> only do >> 1 and carry 1 over to the left
                    carry = 1;
                }
            }
            return steps + carry;
        }
    }
}

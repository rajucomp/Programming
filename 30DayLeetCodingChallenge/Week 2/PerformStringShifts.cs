using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs._30DayLeetCodingChallenge.Week_2
{
    class PerformStringShifts
    {
        public string StringShift(string s, int[][] shift)
        {
            int leftShiftCount = 0, rightShiftCount = 0;

            foreach (var arr in shift)
            {
                if (arr[0] == 0)
                {
                    leftShiftCount += arr[1];
                }
                else
                {
                    rightShiftCount += arr[1];
                }
            }

            leftShiftCount %= s.Length;

            rightShiftCount %= s.Length;

            //Console.WriteLine("Left Shift :- " + leftShiftCount);

            //Console.WriteLine("Right Shift :- " + rightShiftCount);

            if (leftShiftCount == rightShiftCount)
            {
                return s;
            }

            if (leftShiftCount > rightShiftCount)
            {
                return LeftShiftString(s, leftShiftCount - rightShiftCount);
            }

            return RightShiftString(s, rightShiftCount - leftShiftCount);
        }

        public string LeftShiftString(string str, int number)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = number; i < str.Length; i++)
            {
                sb.Append(str[i]);
            }

            for (int i = 0; i < number; i++)
            {
                sb.Append(str[i]);
            }

            return sb.ToString();
        }

        public string RightShiftString(string str, int number)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = str.Length - number; i < str.Length; i++)
            {
                sb.Append(str[i]);
            }

            for (int i = 0; i < str.Length - number; i++)
            {
                sb.Append(str[i]);
            }

            return sb.ToString();
        }
    }
}

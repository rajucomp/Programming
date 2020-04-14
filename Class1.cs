using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs
{
    class Program1
    {
        public static void Main1()
        {
            int size = Convert.ToInt32(Console.ReadLine());

            var str = Console.ReadLine().Split(' ');

            long[] arr = new long[size];

            for(int i = 0; i < size; i++)
            {
                arr[i] = (long)(Convert.ToInt32(str[i]));
            }

            long[] temp = Merge(arr);

            int size1 = 0;

            for(int i = 0; i < size; i++)
            {
                if (temp[i] != -1)
                    size1++;
            }

            Console.WriteLine(size1);

            for(int i = 0; i < temp.Length - 1; i++)
            {
                if (temp[i] != -1)
                    Console.Write(temp[i] + " ");
            }
            Console.Write(temp[temp.Length - 1]);
        }

        public static long[] Merge(long[] arr)
        {
            SortedDictionary<long, List<long>> dict = new SortedDictionary<long, List<long>>();

            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] != -1)
                {
                    if(dict.ContainsKey(arr[i]))
                    {
                        dict[arr[i]].Add(i);
                    }
                    else
                    {
                        dict.Add(arr[i], new List<long>());
                        dict[arr[i]].Add(i);
                    }
                }
            }

            bool needed = false;

            foreach( KeyValuePair<long, List<long>> kvp in dict)
            {
                List<long> lst = kvp.Value;

                if(lst.Count >= 2)
                {
                    needed = true;
                    arr[lst[1]] += arr[lst[0]];
                    arr[lst[0]] = -1;
                    break;
                }
            }

            return needed ? Merge(arr) : arr;
        }
    }
}

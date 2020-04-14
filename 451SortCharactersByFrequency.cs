using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs
{
    class _451SortCharactersByFrequency
    {
        public string TopFrequent(string nums)
        {
            IDictionary<char, int> frequencyDictionary = new Dictionary<char, int>();

            int maximumFrequency = 0;

            foreach (char i in nums)
            {
                if (frequencyDictionary.ContainsKey(i))
                {
                    frequencyDictionary[i] += 1;
                }
                else
                {
                    frequencyDictionary.Add(i, 1);
                }
                maximumFrequency = Math.Max(maximumFrequency, frequencyDictionary[i]);
            }

            List<char>[] bucketSortArray = new List<char>[maximumFrequency + 1];

            for (int i = 0; i < bucketSortArray.Length; i++)
            {
                bucketSortArray[i] = new List<char>();
            }

            foreach (var obj in frequencyDictionary)
            {
                bucketSortArray[obj.Value].Add(obj.Key);
            }

            StringBuilder sb = new StringBuilder();

            for (int i = bucketSortArray.Length - 1; i >= 0; i--)
            {
                int j = 0;
                while (j < bucketSortArray[i].Count)
                {
                    int k = 0;
                    while(k < i)
                    {
                        sb.Append(bucketSortArray[i][j]);
                        k++;
                    }
                    j++;
                }
            }

            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs
{
    class _692TopKFrequentWords
    {
        public IList<string> TopKFrequent(string[] nums, int k)
        {
            IDictionary<string, int> frequencyDictionary = new Dictionary<string, int>();

            int maximumFrequency = 0, minimumFrequency = Int32.MaxValue;

            foreach(string i in nums)
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

                minimumFrequency = Math.Min(minimumFrequency, frequencyDictionary[i]);
            }

            List<string>[] bucketSortArray = new List<string>[maximumFrequency - minimumFrequency + 1];

            for (int i = 0; i < bucketSortArray.Length; i++)
            {
                bucketSortArray[i] = new List<string>();
            }

            foreach (var obj in frequencyDictionary)
            {
                bucketSortArray[obj.Value - minimumFrequency].Add(obj.Key);
            }

            foreach (var obj in frequencyDictionary)
            {
                bucketSortArray[obj.Value - minimumFrequency].Sort();
            }

            IList<string> topKElements = new List<string>();

            for (int i = bucketSortArray.Length - 1; i >= 0 && topKElements.Count < k; i--)
            {
                int j = 0;
                while (j < bucketSortArray[i].Count && topKElements.Count < k)
                {
                    topKElements.Add(bucketSortArray[i][j]);
                    j++;
                }
            }

            return topKElements;
        }
    }
}

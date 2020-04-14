using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs
{
    class _347TopKFrequentElements
    {
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            IDictionary<int, int> frequencyDictionary = new Dictionary<int, int>();

            int maximumFrequency = 0, minimumFrequency = Int32.MaxValue;

            foreach(int i in nums)
            {
                if(frequencyDictionary.ContainsKey(i))
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

            List<int>[] bucketSortArray = new List<int>[maximumFrequency - minimumFrequency + 1];

            for(int i = 0; i < bucketSortArray.Length; i++)
            {
                bucketSortArray[i] = new List<int>();
            }

            foreach(var obj in frequencyDictionary)
            {
                bucketSortArray[obj.Value - minimumFrequency].Add(obj.Key);
            }

            IList<int> topKElements = new List<int>();

            for(int i = bucketSortArray.Length - 1; i >=0 && topKElements.Count < k; i--)
            {
                int j = 0;
                while(j < bucketSortArray[i].Count && topKElements.Count < k)
                {
                    topKElements.Add(bucketSortArray[i][j]);
                    j++;
                }
            }

            return topKElements;
        }
    }
}

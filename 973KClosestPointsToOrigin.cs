using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs
{
    class _973KClosestPointsToOrigin
    {
        private int GetDistanceFromOrigin(int x, int y)
        {
            return x * x + y * y;
        }

        public int[][] KClosest(int[][] points, int K)
        {
            Dictionary<List<int>, int> distanceDictionary = new Dictionary<List<int>, int>();

            int maximumDistance = 0, minimumDistance = Int32.MaxValue;

            foreach (var i in points)
            {
                List<int> point = new List<int>() { i[0], i[1] };
                if (!distanceDictionary.ContainsKey(point))
                {
                    distanceDictionary.Add(point, GetDistanceFromOrigin(i[0], i[1]));
                }

                maximumDistance = Math.Max(maximumDistance, distanceDictionary[point]);

                minimumDistance = Math.Min(minimumDistance, distanceDictionary[point]);
            }

            List<int[]>[] bucketSortArray = new List<int[]>[maximumDistance - minimumDistance + 1];

            for (int i = 0; i < bucketSortArray.Length; i++)
            {
                bucketSortArray[i] = new List<int[]>();
            }

            foreach (var obj in distanceDictionary)
            {
                bucketSortArray[obj.Value - minimumDistance].Add(new int[] { obj.Key[0], obj.Key[1] });
            }

            IList<int[]> topKElements = new List<int[]>();

            for (int i = 0; i < bucketSortArray.Length && K > 0; i++)
            {
                int j = 0;
                while (j < bucketSortArray[i].Count && K > 0)
                {
                    topKElements.Add(bucketSortArray[i][j]);
                    j++;
                    K--;
                }
            }

            int[][] topKPoints = new int[topKElements.Count][];

            for (int i = 0; i < topKElements.Count; i++)
            {
                topKPoints[i] = topKElements[i];
            }

            return topKPoints;

        }

        //public int[][] KClosest(int[][] points, int K)
        //{
        //    int start = 0, end = points.Length - 1;

        //    while (start <= end)
        //    {
        //        int mid = GetPivotPosition(start, end, points, K);

        //        if (mid == K)
        //            break;
        //        else if (mid < K)
        //            start = mid + 1;
        //        else if (mid > K)
        //            end = mid - 1;
        //    }

        //    int[][] closestPoints = new int[K][];
        //    Array.Copy(points, closestPoints, K);

        //    return closestPoints;
        //}

        //private int GetPivotPosition(int start, int end, int[][] points, int K)
        //{
        //    int pivotPosition = start + (end - start) / 2;


        //    while(start <= end)
        //    {

        //    }
        //}
    }


}

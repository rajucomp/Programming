using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs
{
    //https://leetcode.com/problems/last-stone-weight/
    class LastStoneWeightSolution
    {
        public class StonesObject : IComparable<StonesObject>
        {
            public int Value { get; set; }

            public StonesObject(int value)
            {
                Value = value;
            }

            public int CompareTo(StonesObject obj)
            {
                return obj.Value.CompareTo(this.Value);
            }
        }
        public int LastStoneWeight(int[] stones)
        {
            List<StonesObject> sortedStones = new List<StonesObject>();
            

            foreach(int i in stones)
            {
                sortedStones.Add(new StonesObject(i));
            }

            sortedStones.Sort();

            /*
            foreach (var obj in sortedStones)
            {
                Console.WriteLine(obj.Value);
            }
            */

            
            while(sortedStones.Count > 1)
            {
                int result = SmashStones(sortedStones[0].Value, sortedStones[1].Value);

                sortedStones.RemoveAt(0);
                sortedStones.RemoveAt(0);

                if (result != 0)
                {
                    StonesObject newStoneObject = new StonesObject(result);

                    int index = sortedStones.BinarySearch(newStoneObject);

                    if(index < 0)
                    {
                        index = ~index;
                    }
                    sortedStones.Insert(index, newStoneObject);
                }
            }
            

            return sortedStones.Count == 0 ? 0 : sortedStones[0].Value;
        }
        public int SmashStones(int firstStone, int secondStone)
        {
            return firstStone != secondStone ? 
                    firstStone - secondStone : 0;
        }
    }
}

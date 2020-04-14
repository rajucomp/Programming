//using System;
//using System.Collections.Generic;


//namespace CodeForecs
//{
//    public class DictionaryKey
//    {
//        public long Number { get; set; }
        
//        public int Index { get; set; }

//        public DictionaryKey(long number, int index)
//        {
//            Number = number;
//            Index = index;
//        }
//    }

//    public class DictionaryKeyEqualityComparer : IEqualityComparer<DictionaryKey>
//    {
//        public bool Equals(DictionaryKey x, DictionaryKey y)
//        {
//            if (x == null || y == null)
//                return false;

//            if(x.Number == y.Number)
//            {
//                y.Index = x.Index;
//                return true;
//            }

//            return false;
//        }

//        public int GetHashCode(DictionaryKey obj)
//        {
//            return obj.Number.GetHashCode();
//        }
//    }

//    public class DictionaryKeyComparer : Comparer<DictionaryKey>
//    {
//        public override int Compare(DictionaryKey x, DictionaryKey y)
//        {
//            return x.Index.CompareTo(y.Index);
//        }
//    }



//    class MergeEqualsCodeforces
//    {
//        public static void Main(string[] args)
//        {
//            int size = Convert.ToInt32(Console.ReadLine());

//            var inputArray = Console.ReadLine().Split(' ');

//            long[] array = new long[size];

//            DictionaryKeyEqualityComparer dictionaryKeyEqualityComparer = new DictionaryKeyEqualityComparer();

//            IDictionary<DictionaryKey, int> dict = new Dictionary<DictionaryKey, int>(dictionaryKeyEqualityComparer);

//            for(int i = 0; i < size; i++)
//            {
//                array[i] = Convert.ToInt64(inputArray[i]);

//                DictionaryKey obj = new DictionaryKey(array[i], i);

//                Process(obj, i, array, dict);
//            }

//            DictionaryKeyComparer dictionaryKeyComparer = new DictionaryKeyComparer();

//            dict = new SortedDictionary<DictionaryKey, int>(dict, dictionaryKeyComparer);

//            Console.WriteLine(dict.Count);

//            foreach (KeyValuePair<DictionaryKey, int> keyValuePair in dict)
//            {
//                Console.Write(keyValuePair.Key.Number + " ");
//            }

//            //Console.ReadKey();
//        }

//        private static void Process(DictionaryKey obj, int index, long[] array, IDictionary<DictionaryKey, int> dict)
//        {
//            if(dict.ContainsKey(obj))
//            {
//                int oldIndex = obj.Index;
//                array[index] += array[oldIndex];
//                array[oldIndex] = -1;

//                dict.Remove(obj);

//                DictionaryKey obj1 = new DictionaryKey(array[index], index);

//                Process(obj1, index, array, dict);
//            }
//            else
//            {
//                dict.Add(obj, index);
//            }
//        }
//    }
//}

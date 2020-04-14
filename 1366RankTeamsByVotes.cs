//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Linq;

//namespace CodeForecs
//{
//    class _1366RankTeamsByVotes
//    {
//        public class Solution
//        {
//            private char GetPosition(int position, List<char> positionHolders, IDictionary<int, List<char>> dict, string str)
//            {
//                if (positionHolders.Count == 1)
//                    return positionHolders[0];

//                int i = 0;
//                int size = positionHolders.Count;

//                while(i < size - 1)
//                {
//                    if()
//                    i++;
//                }

//                if(i == size - 1)
//                {
//                    Array.Sort(str.ToCharArray());

//                    return str[0];
//                }

//                return positionHolders[i];
//            }

//            private bool GetEqualPosition(char A, char B, int position, IDictionary<int, List<char>> dict)
//            {
//                var lst = dict[position];

//                int countA = lst.Count(x => x == A);

//                int countB = lst.Count(x => x == B);

//                return countA != countB ? (countA > countB ? countA : countB) : GetEqualPosition(A, B, position + 1, dict);

                
//            }
//            public string RankTeams(string[] votes)
//            {
//                int dictSize = votes[0].Length;

//                string str = votes[0];

//                IDictionary<int, List<char>> dict = new Dictionary<int, List<char>>();

//                for(int i = 1; i <= dictSize; i++)
//                {
//                    dict.Add(i, new List<char>());
//                }

//                foreach(string x in votes)
//                {
//                    for(int i = 0; i < x.Length; i++)
//                    {
//                        dict[i].Add(x[i]);
//                    }
//                }

//                StringBuilder sb = new StringBuilder();

//                foreach(KeyValuePair<int, List<char>> keyValuePair in dict)
//                {
//                    sb.Append(GetPosition(keyValuePair.Key, keyValuePair.Value, dict, str));
//                }

//                return sb.ToString();

//            }
//        }
//    }
//}

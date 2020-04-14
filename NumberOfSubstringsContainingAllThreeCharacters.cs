//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace CodeForecs
//{
//    class NumberOfSubstringsContainingAllThreeCharacters
//    {
//        private bool AreAllThreeCharactersContained()
//        {
//            return count[0] >= 1 && count[1] >= 1 && count[2] >= 1;
//        }

//        private int[] count = new int[3];
//        public int NumberOfSubstrings(string s)
//        {
//            long totalCount = 0;

//            for(int i = 0; i < s.Length; i++)
//            {
//                count = new int[3];

//                count[s[i] - 'a']++;

//                for(int j = i + 1; j < s.Length; j++)
//                {
//                    count[s[j] - 'a']++;

//                    if(AreAllThreeCharactersContained())
//                    {
//                        totalCount += (s.Length - j);
//                        break;
//                    }
//                }
//            }
//            return totalCount;
//        }
//    }
//}

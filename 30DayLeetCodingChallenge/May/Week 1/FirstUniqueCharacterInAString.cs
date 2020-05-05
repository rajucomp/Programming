using CodeForecs._30DayLeetCodingChallenge.Week_3;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Schema;

namespace CodeForecs._30DayLeetCodingChallenge.May.Week_1
{
    //https://leetcode.com/problems/first-unique-character-in-a-string/
    class FirstUniqueCharacterInAString
    {
        //The time complexity will be O(n) where n is the length of the string.
        //To be precise, the time complexity is O(2n) since we are scanning the array twice.
        //The space complexity will be O(26) if only lowercase letters are allowed in the input or O(256) if 
        //all the ASCII characters are allowed in the input.
        public int FirstUniqChar(string s)
        {
            //The length of this array should be adjusted according to the number of characters allowed in the input.
            int[] countArray = new int[26];

            //Store the count of each character in the string.
            foreach(char ch in s)
            {
                countArray[ch - 'a']++;
            }

            //Iterate thorugh the string again and return the index of the first character in the string whose count is 1.  
            for(int i = 0; i < s.Length; i++)
            {
                if(countArray[s[i] - 'a'] == 1)
                {
                    return i;
                }
            }

            //If we reach here, this means the input string does not contain any unique character and thus we return -1.
            return -1;
        }

        //The problem with the above method is the second iteration of the string.
        //In the case where a string has billions of characters but only let us say 4 unique characters (like in DNA sequences),
        //we will be unnecessarily iterating through billions of characters and thus it will dramatically increase our running time.
        //In this optimised method, we use a dictionary to store the required information so when we iterate thorugh the second time,
        //we are only iterating through the unique keys in the dictionary.
        //The actual time complexity of this solution will be O(n) where n is the length of the string plus O(k) where k is the number of distince characters in the string i.e O(n+k).
        //The space complexity will be O(k) where k is the number of distinct characters in the string.
        //We iterate once through the string and once through the dictionary.
        public int OptimisedFirstUniqueChar(string s)
        {
            //Create a dictionary that stores the character of the string as key and its index as the value.
            IDictionary<char, int> charCountDictionary = new Dictionary<char, int>();

            for(int i = 0; i < s.Length; i++)
            {
                //If we find a new character, store it in the dictionary along with its count.
                if(!charCountDictionary.ContainsKey(s[i]))
                {
                    charCountDictionary.Add(s[i], i);
                }
                else
                {
                    //This means that the character is repeated more than once.
                    //Thus we don't need its index information and can safely ignore it.
                    charCountDictionary[s[i]] = -1;
                }
            }

            //This variable will hold the minimum index of keys in the dictionary each of which has a valid index i.e. count is 1.
            int minIndex = s.Length + 1;

            foreach(KeyValuePair<char, int> keyValuePair in charCountDictionary)
            {
                //If the index is valid i.e. the count of the key is 1.
                if(keyValuePair.Value != -1)
                {
                    //Calculate the minIndex.
                    minIndex = Math.Min(minIndex, keyValuePair.Value);
                }
            }

            //If there is no unique character in the string, return -1 else return the minIndex.
            return minIndex != s.Length + 1 ? minIndex : -1;
        }
    }
}

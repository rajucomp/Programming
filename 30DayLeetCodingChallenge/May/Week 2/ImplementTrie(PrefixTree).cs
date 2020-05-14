using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs._30DayLeetCodingChallenge.May.Week_2
{
    //https://leetcode.com/problems/implement-trie-prefix-tree/
    class ImplementTrie_PrefixTree_
    {
        public class Trie
        {
            private class TrieNode
            {
                public bool IsAWord { get; set; }

                public TrieNode[] Children = new TrieNode[26];
            }

            private readonly TrieNode rootNode;

            /** Initialize your data structure here. */
            public Trie()
            {
                rootNode = new TrieNode();
            }

            /** Inserts a word into the trie. */
            public void Insert(string word)
            {
                TrieNode tempRootNode = rootNode;

                foreach(char ch in word)
                {
                    if(tempRootNode.Children[ch - 'a'] == null)
                    {
                        tempRootNode.Children[ch - 'a'] = new TrieNode();
                    }

                    tempRootNode = tempRootNode.Children[ch - 'a'];
                }

                tempRootNode.IsAWord = true;

            }

            /** Returns if the word is in the trie. */
            public bool Search(string word)
            {
                return SearchHelper(word, false);
            }

            /** Returns if there is any word in the trie that starts with the given prefix. */
            public bool StartsWith(string prefix)
            {
                return SearchHelper(prefix, true);
            }

            private bool SearchHelper(string word, bool prefix)
            {
                TrieNode tempRootNode = rootNode;

                foreach (char ch in word)
                {
                    if (tempRootNode.Children[ch - 'a'] == null)
                    {
                        return false;
                    }

                    tempRootNode = tempRootNode.Children[ch - 'a'];
                }

                return prefix ? true : tempRootNode.IsAWord;
            }
        }

        /**
         * Your Trie object will be instantiated and called as such:
         * Trie obj = new Trie();
         * obj.Insert(word);
         * bool param_2 = obj.Search(word);
         * bool param_3 = obj.StartsWith(prefix);
         */
    }
}

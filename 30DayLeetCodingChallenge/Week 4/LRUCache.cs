using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs._30DayLeetCodingChallenge.Week_4
{
    public class DoubleLinkedListNode
    {
        public int key { get; set; }
        public int val { get; set; }
        public DoubleLinkedListNode prev = null;
        public DoubleLinkedListNode next = null;

        public DoubleLinkedListNode(int Key, int value)
        {
            key = Key;
            val = value;
        }
    }

    //https://leetcode.com/problems/lru-cache/
    class LRUCache
    {
        public static void TestSolution()
        {
            LRUCache cache = new LRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            Console.WriteLine(cache.Get(1));        // returns 1
            cache.Put(3, 3);                        // evicts key 2
            Console.WriteLine(cache.Get(2));        // returns -1 (not found)
            cache.Put(4, 4);                        // evicts key 1
            Console.WriteLine(cache.Get(1));        // returns -1 (not found)
            Console.WriteLine(cache.Get(3));        // returns 3
            Console.WriteLine(cache.Get(4));        // returns 4

            LRUCache cache1 = new LRUCache(2);
            cache1.Put(2, 1);                       // adds 2
            cache1.Put(1, 1);                       // adds 1
            cache1.Put(2, 3);                       // updates (2,1) to (2,3)
            cache1.Put(4, 1);                       // evicts 1
            Console.WriteLine(cache1.Get(1));       // returns -1
            Console.WriteLine(cache1.Get(2));       // return 3

            LRUCache cache2 = new LRUCache(2);
            Console.WriteLine(cache2.Get(2));       // returns -1
            cache2.Put(2, 6);                       // adds (2,6)
            Console.WriteLine(cache2.Get(1));       // returns -1
            cache2.Put(1, 5);                       // adds (1,5)
            cache2.Put(1, 2);                       // updates (1,5) to (1,2)
            Console.WriteLine(cache2.Get(1));       // returns 2
            Console.WriteLine(cache2.Get(2));       // returns 6

            LRUCache cache3 = new LRUCache(2);
            cache2.Put(2, 1);                       // adds (2,1)
            Console.WriteLine(cache2.Get(2));       // returns 1


        }

        private Dictionary<int, DoubleLinkedListNode> dict;

        private int _capacity { get; set; }

        private DoubleLinkedListNode dummyHeadNode = new DoubleLinkedListNode(0, 0);

        private DoubleLinkedListNode dummyLastNode = new DoubleLinkedListNode(0, 0);

        //Implement a LRU cache with the specified capacity.
        public LRUCache(int capacity)
        {
            dict = new Dictionary<int, DoubleLinkedListNode>(capacity);

            _capacity = capacity;

            InitialiseDummyHeadAndTailPointers();
        }

        //Initialise dummy head and last nodes pointers to avoid extra null checking.
        private void InitialiseDummyHeadAndTailPointers()
        {
            dummyHeadNode.next = dummyLastNode;
            dummyLastNode.prev = dummyHeadNode;
        }

        //Returns the value of the specified key in O(1) time..
        public int Get(int key)
        {
            if(dict.ContainsKey(key))
            {
                DoubleLinkedListNode node = dict[key];

                RemoveNode(node);

                InsertNode(node);

                return node.val;
            }

            return -1;

        }

        //Adds or updates the key in the cache in O(1) time.
        public void Put(int key, int value)
        {
            if(dict.ContainsKey(key))
            {
                RemoveNode(dict[key]);
            }

            DoubleLinkedListNode nodeToAdd = new DoubleLinkedListNode(key, value);

            if(dict.Count == _capacity)
            {
                //If capacity is full, remove the node just before the dummy last node.
                RemoveNode(dummyLastNode.prev);
            }

            InsertNode(nodeToAdd);

        }

        //Inserts the node after the dummy head node.
        private void InsertNode(DoubleLinkedListNode nodeToAdd)
        {
            //Add the key to the dictionary.
            dict.Add(nodeToAdd.key, nodeToAdd);

            nodeToAdd.next = dummyHeadNode.next;
            nodeToAdd.prev = dummyHeadNode;

            dummyHeadNode.next.prev = nodeToAdd;
            dummyHeadNode.next = nodeToAdd;
        }

        //Removes the node.
        private void RemoveNode(DoubleLinkedListNode nodeToRemove)
        {
            //Remove the key from the dictionary.
            dict.Remove(nodeToRemove.key);

            //Update the prev and the next pointers.
            nodeToRemove.prev.next = nodeToRemove.next;
            nodeToRemove.next.prev = nodeToRemove.prev;
        }
    }
}

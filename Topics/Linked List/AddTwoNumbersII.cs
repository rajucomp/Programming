using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs.Topics.Linked_List
{
    public class ListNode
    {
        public int val { get; set; }
        public ListNode next { get; set; }
        public ListNode(int x)
        {
            val = x;
        }
    }
    //https://leetcode.com/problems/add-two-numbers-ii/
    class AddTwoNumbersII
    {
        public ListNode ReverseLinkedList(ListNode headNode)
        {
            ListNode currentNode = headNode;
            ListNode previousNode = null;
            ListNode nextNode = null;

            while (currentNode != null)
            {
                nextNode = currentNode.next;
                currentNode.next = previousNode;
                previousNode = currentNode;
                currentNode = nextNode;
            }

            return previousNode;
        }

        public void Display(ListNode headNode)
        {
            ListNode tempNode = headNode;

            while (tempNode.next != null)
            {
                Console.Write(tempNode.val + " ");
                tempNode = tempNode.next;
            }

            Console.WriteLine(tempNode.val);
        }

        //This solution is used when reversing the linked list is allowed.
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode reversedFirstNode = ReverseLinkedList(l1);
            ListNode reversedSecondNode = ReverseLinkedList(l2);

            //Display(reversedFirstNode);
            //Display(reversedSecondNode);

            int sum = 0, carry = 0;

            ListNode resultNode = null, lastNode = null;

            while (reversedFirstNode != null && reversedSecondNode != null)
            {
                //Console.WriteLine("First Node :- " + reversedFirstNode.val + " Second Node :- " + reversedSecondNode.val);

                sum = reversedFirstNode.val + reversedSecondNode.val + carry;

                carry = sum / 10;

                sum %= 10;

                //Console.WriteLine("Sum :- " + sum + " Carry :- " + carry);

                if (resultNode == null)
                {
                    resultNode = new ListNode(sum);
                    lastNode = resultNode;
                }
                else
                {
                    lastNode.next = new ListNode(sum);
                    lastNode = lastNode.next;
                }

                reversedFirstNode = reversedFirstNode.next;
                reversedSecondNode = reversedSecondNode.next;

                //Display(resultNode);
            }

            while (reversedFirstNode != null)
            {
                sum = reversedFirstNode.val + carry;

                carry = sum / 10;

                sum %= 10;

                if (resultNode == null)
                {
                    resultNode = new ListNode(sum);
                    lastNode = resultNode;
                }
                else
                {
                    lastNode.next = new ListNode(sum);
                    lastNode = lastNode.next;
                }

                reversedFirstNode = reversedFirstNode.next;
            }

            while (reversedSecondNode != null)
            {
                sum = reversedSecondNode.val + carry;

                carry = sum / 10;

                sum %= 10;

                if (resultNode == null)
                {
                    resultNode = new ListNode(sum);
                    lastNode = resultNode;
                }
                else
                {
                    lastNode.next = new ListNode(sum);
                    lastNode = lastNode.next;
                }

                reversedSecondNode = reversedSecondNode.next;
            }

            if (carry > 0)
            {
                lastNode.next = new ListNode(carry);
                lastNode = lastNode.next;
            }

            //Display(resultNode);

            return ReverseLinkedList(resultNode);
        }

        //This solution is used when reversing the linked list is not allowed.
        public ListNode AddTwoNumbersWithoutReversing(ListNode nodeA, ListNode nodeB)
        {
            Stack<int> firstNodeStack = new Stack<int>();
            Stack<int> secondNodeStack = new Stack<int>();

            PushLinkedListIntoStack(nodeA, firstNodeStack);
            PushLinkedListIntoStack(nodeB, secondNodeStack);

            int sum = 0, carry = 0;

            ListNode resultNode = null, lastNode = null;

            while (firstNodeStack.Count != 0 && secondNodeStack.Count != 0)
            {
                sum = firstNodeStack.Pop() + secondNodeStack.Pop() + carry;

                carry = sum / 10;

                sum %= 10;

                //Console.WriteLine("Sum :- " + sum + " Carry :- " + carry);

                if (resultNode == null)
                {
                    resultNode = new ListNode(sum);
                    lastNode = resultNode;
                }
                else
                {
                    lastNode.next = new ListNode(sum);
                    lastNode = lastNode.next;
                }

                //Display(resultNode);
            }

            while (firstNodeStack.Count != 0)
            {
                sum = firstNodeStack.Pop() + carry;

                carry = sum / 10;

                sum %= 10;

                if (resultNode == null)
                {
                    resultNode = new ListNode(sum);
                    lastNode = resultNode;
                }
                else
                {
                    lastNode.next = new ListNode(sum);
                    lastNode = lastNode.next;
                }

            }

            while (secondNodeStack.Count != 0)
            {
                sum = secondNodeStack.Pop() + carry;

                carry = sum / 10;

                sum %= 10;

                if (resultNode == null)
                {
                    resultNode = new ListNode(sum);
                    lastNode = resultNode;
                }
                else
                {
                    lastNode.next = new ListNode(sum);
                    lastNode = lastNode.next;
                }

            }

            if (carry > 0)
            {
                lastNode.next = new ListNode(carry);
                lastNode = lastNode.next;
            }

            //Display(resultNode);

            return ReverseLinkedList(resultNode);
        }

        public void PushLinkedListIntoStack(ListNode headNode, Stack<int> stack)
        {
            ListNode currentNode = headNode;

            while(currentNode != null)
            {
                stack.Push(currentNode.val);
                currentNode = currentNode.next;
            }
        }
    }
}

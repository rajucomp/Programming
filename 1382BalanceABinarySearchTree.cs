using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs
{
    class _1382BalanceABinarySearchTree
    {
        /**
         * Definition for a binary tree node.
         * */
          public class TreeNode {
              public int val;
              public TreeNode left;
              public TreeNode right;
              public TreeNode(int x) { val = x; }
         }
        
        public class Solution
        {
            public int GetHeight(TreeNode root)
            {
                if (root == null)
                    return 0;

                int leftHeight = GetHeight(root.left);
                int rightHeight = GetHeight(root.right);

                return 1 + Math.Max(leftHeight, rightHeight);
            }
                public TreeNode BalanceBST(TreeNode root)
                {
                    int leftHeight = GetHeight(root.left);
                    int rightHeight = GetHeight(root.right);

                    Console.Write("Left Height :- ");
                    Console.WriteLine(leftHeight);
                    Console.Write("Right Height :- ");
                    Console.WriteLine(rightHeight);

                    if(leftHeight - rightHeight >= 2)
                    {
                        TreeNode temp = root;
                        root = root.left;
                        root.right = temp;
                    }
                    else if (rightHeight - leftHeight >= 2)
                    {
                        TreeNode temp = root;
                        root = root.right;
                        root.left = temp;
                    }

                    return root;
                }
        }
    }
}

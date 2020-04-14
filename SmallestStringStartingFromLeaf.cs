using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs
{
    //https://leetcode.com/problems/smallest-string-starting-from-leaf/
    class SmallestStringStartingFromLeaf
    {
        public string SmallestFromLeaf(TreeNode root)
        {
            StringBuilder result = new StringBuilder();

            SmallestFromLeafHelper(root, result, "");

            return result.ToString();
        }

        public void SmallestFromLeafHelper(TreeNode root, StringBuilder result, string pathString)
        {
            if (root == null)
            {
                return;
            }

            if (root.left == null && root.right == null)
            {
                //Add the character backwards to avoid reversing the string later.
                pathString = Convert.ToChar('a' + root.val) + pathString;

                if(result.ToString() == string.Empty)
                {
                    result.Append(pathString);
                }
                else if(string.Compare(result.ToString(), pathString) > 0)
                {
                    result.Clear();
                    result.Append(pathString);
                }

                //Console.WriteLine(result);
                return;
            }

            pathString = Convert.ToChar('a' + root.val) + pathString;

            SmallestFromLeafHelper(root.left, result, pathString);

            SmallestFromLeafHelper(root.right, result, pathString);
        }
    }
}

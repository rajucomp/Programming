using System;
using System.Collections.Generic;
using System.Text;

namespace CodeForecs
{
    //https://leetcode.com/problems/sum-root-to-leaf-numbers/
    class SumRootToLeafNumbers
    {
        public int SumNumbers(TreeNode root)
        {
            int result = 0;

            SumNumbersHelper(root, ref result, "");

            return result;
        }

        public void SumNumbersHelper(TreeNode root, ref int result, string pathString)
        {
            if (root == null)
            {
                return;
            }

            if (root.left == null && root.right == null)
            {
                pathString += root.val.ToString();
                result += Convert.ToInt32(pathString);
                return;
            }

            pathString += root.val.ToString();

            SumNumbersHelper(root.left, ref result, pathString);

            SumNumbersHelper(root.right, ref result, pathString);
        }
    }

}

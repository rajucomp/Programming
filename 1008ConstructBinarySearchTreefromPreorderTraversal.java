//https://leetcode.com/problems/construct-binary-search-tree-from-preorder-traversal/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
class Solution {
    
    TreeNode bstFromPreorderStackSolution(int[] preorder) {
        Stack<TreeNode> stack = new Stack();
        
        TreeNode root = new TreeNode(preorder[0]);
        stack.push(root);
        
        for(int i = 1; i < preorder.length; i++) {
            TreeNode currentNode = new TreeNode(preorder[i]);
            if(preorder[i] < stack.peek().val) {
                stack.peek().left = currentNode;
            }
            else {
                TreeNode recentlyPopped = null;
                while(!stack.isEmpty() && stack.peek().val < preorder[i]) {
                    recentlyPopped = stack.pop();
                }
                recentlyPopped.right = currentNode;
            }
            stack.push(currentNode);
        }
        
        return root;
    }
    public TreeNode bstFromPreorder(int[] preorder) {
        //return bstFromPreorder(preorder, 0, preorder.length - 1);
        return bstFromPreorderStackSolution(preorder);
    }
    
    TreeNode bstFromPreorder(int[] preorder, int start, int end) {
        if(start > end) {
            return null;
        }
        TreeNode root = new TreeNode(preorder[start]);
        
        int rightIndex = binarySearch(preorder, start + 1, end, preorder[start]);
        
        root.left = bstFromPreorder(preorder, start + 1, rightIndex - 1);
        root.right = bstFromPreorder(preorder, rightIndex, end);
        
        return root;
    }
    
    int binarySearch(int[] arr, int start, int end, int key) {
        while(start <= end) {
            int mid = start + (end - start) / 2;
            
            if(arr[mid] == key) {
                return mid;
            }
            
            if(arr[mid] < key) {
                start = mid + 1;
            }
            else {
                end = mid - 1;
            }
        }
        
        return start;
    }
}

//https://leetcode.com/problems/sum-of-nodes-with-even-valued-grandparent/


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
    public int sumEvenGrandparent(TreeNode root) {
        //return dfs(root, null, null);
        return bfs(root);
    }
    
    int bfs(TreeNode root) {
        int sum = 0;
        Queue<TreeNode[]> queue = new LinkedList();
        queue.add(new TreeNode[]{root, null, null});
        while(!queue.isEmpty()) {
            TreeNode[] top = queue.remove();
            if(top[2] != null && top[2].val % 2 == 0) {
                sum += top[0].val;
            }
            if(top[0].left != null) {
                queue.add(new TreeNode[]{top[0].left, top[0], top[1]});
            }
            if(top[0].right != null) {
                queue.add(new TreeNode[]{top[0].right, top[0], top[1]});
            }
        }
        return sum;
    }
    
    int dfs(TreeNode root, TreeNode parent, TreeNode grandParent) {
        if(root == null) {
            return 0;
        }
        int sum = 0;
        if(grandParent != null && grandParent.val % 2 == 0) {
            sum += root.val;
        }
        sum += dfs(root.left, root, parent);
        sum += dfs(root.right, root, parent);
        return sum;
    }
}

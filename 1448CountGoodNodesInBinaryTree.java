//https://leetcode.com/problems/count-good-nodes-in-binary-tree/

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
    public int goodNodes(TreeNode root) {
        //return dfs(root, root.val);
        return bfs(root);
    }
    
    int bfs(TreeNode root) {
        int sum = 0;
        Queue<Pair<TreeNode, Integer>> queue = new LinkedList();
        queue.add(new Pair<>(root, root.val));
        while(!queue.isEmpty()) {
            Pair<TreeNode, Integer> node = queue.remove();
            if(node.getKey().val >= node.getValue()) {
                sum += 1;
            }
            if(node.getKey().left != null) {
                queue.add(new Pair<>(node.getKey().left, Math.max(node.getKey().left.val, node.getValue())));
            }
            if(node.getKey().right != null) {
                queue.add(new Pair<>(node.getKey().right, Math.max(node.getKey().right.val, node.getValue())));
            }
        }
        return sum;
    }
    
    int dfs(TreeNode root, int maxValue) {
        if(root == null) {
            return 0;
        }
        int sum = 0;
        if(root.val >= maxValue) {
            sum += 1;
            maxValue = root.val;
        }
        sum += dfs(root.left, maxValue);
        sum += dfs(root.right, maxValue);
        return sum;
    }
}

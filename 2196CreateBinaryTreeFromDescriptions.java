//https://leetcode.com/problems/create-binary-tree-from-descriptions/

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
    class TreeNodeWithParent extends TreeNode {
        TreeNode parent;
        public TreeNodeWithParent(int val, TreeNode left, TreeNode right) {
            super(val, left, right);
        }
        
        public TreeNodeWithParent(int val) {
            super(val);
        }
    }
    public TreeNode createBinaryTree(int[][] descriptions) {
        Map<Integer, TreeNodeWithParent> map = new HashMap();
        for(int[] arr : descriptions) {
            map.put(arr[0], map.getOrDefault(arr[0], new TreeNodeWithParent(arr[0])));
            map.put(arr[1], map.getOrDefault(arr[1], new TreeNodeWithParent(arr[1])));
            if(arr[2] == 1) {
                map.get(arr[0]).left = map.get(arr[1]);
            } else {
                map.get(arr[0]).right = map.get(arr[1]);
            }
            map.get(arr[1]).parent = map.get(arr[0]);
        }
        
        for(Map.Entry<Integer, TreeNodeWithParent> kv : map.entrySet()) {
            if(kv.getValue().parent == null) {
                return kv.getValue();
            }
        }
        
        return null;
    }
}

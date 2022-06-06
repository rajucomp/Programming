//https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree/

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
    int bfs(TreeNode root) {
        Queue<TreeNode> queue = new LinkedList();
        queue.add(root);
        int minLevelSum = Integer.MIN_VALUE, minLevel = 1, level = 1;
        while(!queue.isEmpty()) {
            int size = queue.size();
            int currentLevelSum = 0;
            for(int i = 0; i < size; i++) {
                TreeNode node = queue.remove();
                currentLevelSum += node.val;
                if(node.left != null) {
                    queue.add(node.left);
                }
                if(node.right != null) {
                    queue.add(node.right);
                }
            }
            if(minLevelSum < currentLevelSum) {
                minLevelSum = currentLevelSum;
                minLevel = level;
            }
            level++;
        }
        return minLevel;
    }
    
    public int maxLevelSum(TreeNode root) {
        //return bfs(root);
        return dfsWithMap(root);
    }
    
    int dfsWithoutMap(TreeNode root) {
        List<Integer> levelSumList = new ArrayList();
        dfs(root, levelSumList, 1);
        int maxLevelSum = root.val, minLevel = 1;
        for(int i = 0; i < levelSumList.size(); i++) {
            if(levelSumList.get(i) > maxLevelSum) {
                maxLevelSum = levelSumList.get(i);
                minLevel = i;
            }
        }
        return minLevel;
    }
    
    int dfsWithMap(TreeNode root) {
        Map<Integer, Integer> levelSumMap = new HashMap();
        dfs(root, levelSumMap, 1);
        int maxLevelSum = root.val, minLevel = 1;
        for(Map.Entry<Integer, Integer> entry : levelSumMap.entrySet()) {
            if(entry.getValue() > maxLevelSum) {
                maxLevelSum = entry.getValue();
                minLevel = entry.getKey();
            }
            else if(entry.getValue() == maxLevelSum) {
                minLevel = Math.min(minLevel, entry.getKey());
            }
            
        }
        return minLevel;
    }
    
    void dfs(TreeNode root, Map<Integer, Integer> levelSumMap, int currentLevel) {
        if(root == null) {
            return;
        }
        levelSumMap.put(currentLevel, levelSumMap.getOrDefault(currentLevel, 0) + root.val);
        dfs(root.left, levelSumMap, currentLevel + 1);
        dfs(root.right, levelSumMap, currentLevel + 1);
    }
    
    void dfs(TreeNode root, List<Integer> levelSumList, Integer currentLevel) {
        if(root == null) {
            return;
        }
        if(currentLevel > levelSumList.size()) {
            levelSumList.add(root.val);
        }
        else {
            levelSumList.set(currentLevel - 1, levelSumList.get(currentLevel - 1) + root.val);
        }
        dfs(root.left, levelSumList, currentLevel + 1);
        dfs(root.right, levelSumList, currentLevel + 1);
    }
}

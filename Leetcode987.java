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
    class Pair
    {
        TreeNode first;
        int second;
        int level;
        public Pair(TreeNode root, int val, int lev)
        {
            first = root;
            second = val;
            level = lev;
        }
    }
    
    public List<List<Integer>> verticalTraversal(TreeNode root) {
        TreeMap<Integer, List<Pair>> map = new TreeMap();
        List<List<Integer>>  result = new ArrayList();
        Queue<Pair> queue = new ArrayDeque();
        int level = 0;
        queue.add(new Pair(root, 0, level));
        
        while(!queue.isEmpty())
        {
            int size = queue.size();
            
            for(int i = 0; i < size; i++){
                Pair pair = queue.poll();
                
                List<Pair> currentList = map.getOrDefault(pair.second, new ArrayList());
                currentList.add(new Pair(pair.first, pair.second, level));
                map.put(pair.second, currentList);
                if(pair.first.left != null)
                {
                    queue.add(new Pair(pair.first.left, pair.second - 1, level));
                }
                if(pair.first.right != null)
                {
                    queue.add(new Pair(pair.first.right, pair.second + 1, level));
                }
            }
            level++;
        }                      
        
        for(Map.Entry<Integer, List<Pair>> entry : map.entrySet())
        {
            Collections.sort(entry.getValue(), (a, b) -> 
                             a.second == b.second ? 
                             a.level == b.level ? a.first.val - b.first.val : a.level - b.level
                            :a.second - b.second);
            List<Integer> currentList = new ArrayList<>();
            for(Pair pair : entry.getValue()){
                currentList.add(pair.first.val);
            }
            result.add(currentList);
        }
        return result;   
    }
}

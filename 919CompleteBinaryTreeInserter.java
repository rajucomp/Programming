//https://leetcode.com/problems/complete-binary-tree-inserter/

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
class CBTInserter {
    
    List<TreeNode> tree;

    public CBTInserter(TreeNode root) {
        tree = new ArrayList();
        bfs(root);
    }
    
    public int insert(int val) {
        tree.add(new TreeNode(val));
        TreeNode parent = null;
        if(tree.size() % 2 == 0) {
            parent = tree.get((tree.size() - 1) / 2);
            parent.left = tree.get(tree.size() - 1);
        }
        else {
            parent = tree.get((tree.size() - 2) / 2);
            parent.right = tree.get(tree.size() - 1);
        }
        return parent.val;
    }
    
    public TreeNode get_root() {
        return tree.get(0);
    }
    
    void bfs(TreeNode root) {
        Queue<TreeNode> queue = new LinkedList();
        queue.offer(root);
        while(!queue.isEmpty()) {
            TreeNode node = queue.poll();
            tree.add(node);
            if(node.left != null) {
                queue.offer(node.left);
            }
            if(node.right != null) {
                queue.offer(node.right);
            }
        }
    }
}

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
class CBTInserter {
    TreeNode root;
    Queue<TreeNode> nodeQueue;

    public CBTInserter(TreeNode root) {
        nodeQueue = new LinkedList();
        bfs(root);
    }
    
    public int insert(int val) {
        return insert(new TreeNode(val));
    }
    
    int insert(TreeNode val) {
        TreeNode node = nodeQueue.peek();
        if(node.left == null) {
            node.left = val;
        }
        else {
            node.right = val;
            nodeQueue.poll();
            nodeQueue.offer(node.left);
            nodeQueue.offer(node.right);
        }
        return node.val;
    }
    
    public TreeNode get_root() {
        return this.root;
    }
    
    void bfs(TreeNode root) {
        Queue<TreeNode> queue = new LinkedList();
        queue.offer(root);
        TreeNode newRoot = new TreeNode(root.val);
        this.root = newRoot;
        nodeQueue.add(newRoot);
        while(!queue.isEmpty()) {
            TreeNode node = queue.poll();
            if(node.left != null) {
                queue.offer(node.left);
                insert(new TreeNode(node.left.val));
            }
            if(node.right != null) {
                queue.offer(node.right);
                insert(new TreeNode(node.right.val));
            }
        }
    }
}

/**
 * Your CBTInserter object will be instantiated and called as such:
 * CBTInserter obj = new CBTInserter(root);
 * int param_1 = obj.insert(val);
 * TreeNode param_2 = obj.get_root();
 */

/**
 * Your CBTInserter object will be instantiated and called as such:
 * CBTInserter obj = new CBTInserter(root);
 * int param_1 = obj.insert(val);
 * TreeNode param_2 = obj.get_root();
 */

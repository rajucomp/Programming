/**
 * Definition for binary tree
 * class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) {
 *      val = x;
 *      left=null;
 *      right=null;
 *     }
 * }
 
 https://www.interviewbit.com/problems/vertical-order-traversal-of-binary-tree/
 */

public class Solution {
    class Pair
{
    public final TreeNode first;       // first field of a pair
    public final Integer second;      // second field of a pair
 
    // Constructs a new Pair with specified values
    public Pair(TreeNode first, Integer second)
    {
        this.first = first;
        this.second = second;
    }
    
}
    int maxNode = Integer.MIN_VALUE, minNode = Integer.MAX_VALUE;
    public int[][] verticalOrderTraversal(TreeNode A) {

        initialiseMinAndMaxNode(A, 0);

        int width = maxNode - minNode + 1;

        //System.out.println(width);

        List<List<Integer>> result = new ArrayList();

        TreeMap<Integer, List<Integer>> map = new TreeMap();

        /*
        for(int i = minNode; i <= maxNode; i++)
        {
            List<Integer> currentList = new ArrayList();
            traverse(A, i, 0, currentList, map);
            result.add(currentList);
        }
        */

        traverse(A, map);




        int[][] answer = new int[map.size()][];
        int k = 0;

        for(Map.Entry<Integer, List<Integer>> entry : map.entrySet())
        {
            answer[k] = new int[entry.getValue().size()];
            for(int j = 0; j < entry.getValue().size(); j++)
            {
                answer[k][j] = entry.getValue().get(j);
                //System.out.print(answer[i][j] + " ");
            }
            k++;
        }

        /*

        for(int i = 0; i < result.size(); i++)
        {
            answer[i] = new int[result.get(i).size()];

            for(int j = 0; j < result.get(i).size(); j++)
            {
                answer[i][j] = result.get(i).get(j);
                //System.out.print(answer[i][j] + " ");
            }

            //System.out.println();
        }

        */

        

        return answer;
    }

    void traverse(TreeNode root, TreeMap<Integer, List<Integer>> map)
    {
        if(root == null)
        {
            return;
        }
        Queue<Pair> queue = new ArrayDeque();
        queue.add(new Pair(root, 0));

        //System.out.println("Initlaisng Queue");

        while(!queue.isEmpty())
        {
            int size = queue.size();
            //System.out.println("Current size " + size);

            for(int i = 0; i < size; i++)
            {
                Pair pair = queue.poll();

                //System.out.println(pair.first.val + " " + pair.second);

                //System.out.println("Size of queue after polling " + queue.size());

                List<Integer> currentList = map.getOrDefault(pair.second, new ArrayList());
                currentList.add(pair.first.val);
                map.put(pair.second, currentList);

                /*
                if(pair.second == requiredVerticalLevel)
                {
                    result.add(pair.first.val);
                }
                */

                if(pair.first.left != null) {
                    //System.out.println("Adding left child " + pair.first.left.val);
                    queue.add(new Pair(pair.first.left, pair.second - 1));
                }
                if(pair.first.right != null) {
                    //System.out.println("Adding right child " + pair.first.right.val);
                    queue.add(new Pair(pair.first.right, pair.second + 1));
                }

                //System.out.println("Size of queue after adding " + queue.size());
            }
        }

        /*
        if(root == null)
        {
            return;
        }

        if(currentVerticalLevel == requiredVerticalLevel)
        {
            result.add(root.val);
            //return;
        }

        traverse(root.left, requiredVerticalLevel, currentVerticalLevel - 1, result);
        traverse(root.right, requiredVerticalLevel, currentVerticalLevel + 1, result);

        */
    }

    void initialiseMinAndMaxNode(TreeNode root, int currentVerticalLevel)
    {
        if(root == null)
        {
            return;
        }

        minNode = Math.min(minNode, currentVerticalLevel);
        maxNode = Math.max(maxNode, currentVerticalLevel);
        initialiseMinAndMaxNode(root.left, currentVerticalLevel - 1);
        initialiseMinAndMaxNode(root.right, currentVerticalLevel + 1);
    }
}

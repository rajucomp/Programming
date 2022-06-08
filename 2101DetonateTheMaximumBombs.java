//https://leetcode.com/problems/detonate-the-maximum-bombs/

class Solution {
    boolean isReachable(int[] a, int[] b) {
        long dx = (long)a[0] - (long)b[0], dy = (long)a[1] - (long)b[1], r = (long)a[2];
        return dx * dx + dy * dy <= r * r;
    }
    
    public int maximumDetonation(int[][] bombs) {
        List<List<Integer>> graph = new ArrayList<>();
        for(int i = 0; i < bombs.length; i++) {
            graph.add(new ArrayList<>());
        }
        
        for(int i = 0; i < bombs.length; i++) {
            for(int j = 0; j < bombs.length; j++) {
                if(i != j && isReachable(bombs[i], bombs[j])) {
                    graph.get(i).add(j);
                }
            }
        }
        
        int maxBomb = 1;
        for(int i = 0; i < bombs.length; i++) {
            boolean[] visited = new boolean[bombs.length];
            //maxBomb = Math.max(maxBomb, dfs(i, graph, visited));
            maxBomb = Math.max(maxBomb, bfs(i, graph, visited));
        }
        
        return maxBomb;
    }
    
    int bfs(int source, List<List<Integer>> graph, boolean[] visited) {
        Queue<Integer> queue = new LinkedList();
        queue.offer(source);
        visited[source] = true;
        
        int count = 0;
        
        while(!queue.isEmpty()) {
            Integer top = queue.poll();
            count++;
            for(Integer neighbour : graph.get(top)) {
                if(!visited[neighbour]) {
                    visited[neighbour] = true;
                    queue.offer(neighbour);
                }
            }
        }
        
        return count;
    }
    
    int dfs(Integer point, List<List<Integer>> graph, boolean[] visited) {
        if(visited[point]) {
            return 0;
        }
        
        visited[point] = true;
        int currentValue = 1;
        for(Integer neighbour : graph.get(point)) {
            currentValue += dfs(neighbour, graph, visited);
        }
        return currentValue;
    }
}

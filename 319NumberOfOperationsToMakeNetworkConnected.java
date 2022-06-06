// https://leetcode.com/problems/number-of-operations-to-make-network-connected/

class Solution {
    List<List<Integer>> buildGraph(int n, int[][] connections) {
        List<List<Integer>> graph = new ArrayList();
        for(int i = 0; i < n; i++) {
            graph.add(new ArrayList());
        }
    
        for(int[] arr : connections) {
            graph.get(arr[0]).add(arr[1]);
            graph.get(arr[1]).add(arr[0]);
        }
        return graph;
    }
    
    public int makeConnected(int n, int[][] connections) {
        List<List<Integer>> graph = buildGraph(n, connections);
        boolean[] visited = new boolean[n];
        int count = 0;
        
        for(int i = 0; i < n; i++) {
            if(!visited[i]) {
                count++;
                dfs(i, graph, visited);
                //bfs(i, graph, visited);
            }
        }
        return connections.length >= n - 1 ? count - 1 : -1;
    }
    
    void dfs(Integer i, List<List<Integer>> graph, boolean[] visited) {
        visited[i] = true;
        for(Integer neighbour : graph.get(i)) {
            if(!visited[neighbour]) {
                dfs(neighbour, graph, visited);
            }   
        }
    }
    
    void bfs(int i, List<List<Integer>> graph, boolean[] visited) {
        Queue<Integer> queue = new LinkedList();
        queue.offer(i);
        visited[i] = true;
        while(!queue.isEmpty()) {
            for(Integer neighbour : graph.get(queue.poll())) {
                if(!visited[neighbour]) {
                    visited[neighbour] = true;
                    queue.offer(neighbour);
                }
            }
        }
    }
}

//https://leetcode.com/problems/find-if-path-exists-in-graph/

class Solution {
    Map<Integer, List<Integer>> buildGraph(int[][] edges, int n) {
        Map<Integer, List<Integer>> graph = new HashMap();
        for(int i = 0; i < n; i++) {
            graph.put(i, new ArrayList());
        }
        for(int[] edge : edges) {
            graph.get(edge[0]).add(edge[1]);
            graph.get(edge[1]).add(edge[0]);
        }
        return graph;
    }
    
    
    public boolean validPath(int n, int[][] edges, int source, int destination) {
        Map<Integer, List<Integer>> graph = buildGraph(edges, n);
        boolean[] visited = new boolean[n];
        //return dfs(source, graph, visited, destination);
        return bfs(source, graph, visited, destination);
    }
    
    boolean bfs(int source, Map<Integer, List<Integer>> graph, boolean[] visited, int destination) {
        Queue<Integer> queue = new LinkedList();
        queue.add(source);
        
        while(!queue.isEmpty()) {
            Integer top = queue.remove();
            visited[top] = true;
            if(top == destination) {
                return true;
            }
            for(Integer neighbour : graph.get(top)) {
                if(!visited[neighbour]) {
                    queue.add(neighbour);
                }
            }
        }
        return false;
    }
    
    boolean dfs(Integer currentNode, Map<Integer, List<Integer>> graph, boolean[] visited, int destination) {
        if(currentNode == destination) {
            return true;
        }
        
        visited[currentNode] = true;
        for(Integer neighbour: graph.get(currentNode)) {
            if(!visited[neighbour]) {
                if(dfs(neighbour, graph, visited, destination)) {
                    return true;
                }
            }
        }
        return false;
    }
}

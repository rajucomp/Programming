//https://leetcode.com/problems/time-needed-to-inform-all-employees/

class Solution {
    public int numOfMinutes(int n, int headID, int[] manager, int[] informTime) {
        Map<Integer, List<Integer>> map = new HashMap();
        for(int i = 0; i < n; i++) {
            map.put(i, new ArrayList());
        }
        for(int i = 0; i < n; i++) {
            if(manager[i] != -1) {
                map.get(manager[i]).add(i);
            }
        }
        return dfs(headID, map, informTime, 0);
        //return bfs(headID, map, informTime);
    }
    
    int dfs(int id, Map<Integer, List<Integer>> map, int[] informTime, int time) {
        int maxTime = time;
        for(Integer employeeId : map.get(id)) {
            maxTime = Math.max(maxTime, dfs(employeeId, map, informTime, time + informTime[id]));
        }
        return maxTime;
    }
    
    int bfs(int id, Map<Integer, List<Integer>> map, int[] informTime) {
        Queue<Integer[]> queue = new LinkedList();
        queue.offer(new Integer[]{id, 0});
        int time = 0;
        while(!queue.isEmpty()) {
            Integer[] top = queue.poll();
            time = Math.max(time, top[1]);
            for(Integer empId : map.get(top[0])) {
                queue.offer(new Integer[]{empId, top[1] + informTime[top[0]]});
            }
        }
        return time;
    }
}

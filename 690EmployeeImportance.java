//https://leetcode.com/problems/employee-importance/

/*
// Definition for Employee.
class Employee {
    public int id;
    public int importance;
    public List<Integer> subordinates;
};
*/

class Solution {
    public int getImportance(List<Employee> employees, int id) {
        Map<Integer, Employee> map = new HashMap();
        for(Employee emp : employees) {
            map.put(emp.id, emp);
        }
        //return dfs(id, map);
        return bfs(id, map);
    }
    
    int dfs(Integer id, Map<Integer, Employee> map) {
        int currentSum = map.get(id).importance;
        for(Integer subordinate : map.get(id).subordinates) {
            currentSum += dfs(subordinate, map);
        }
        return currentSum;
    }
    
    int bfs(Integer id, Map<Integer, Employee> map) {
        Queue<Integer> queue = new LinkedList();
        queue.add(id);
        int sum = 0;
        while(!queue.isEmpty()) {
            Employee employee = map.get(queue.remove());
            sum += employee.importance;
            for(Integer subordinate : employee.subordinates) {
                queue.add(subordinate);
            }
        }
        return sum;
    }
}

//https://leetcode.com/problems/find-all-groups-of-farmland/

class Solution {
    public int[][] findFarmland(int[][] land) {
        List<Integer[]> answer = new ArrayList();
        int rows = land.length, cols = land[0].length;
        
        for(int i = 0; i < rows; i++) {
            for(int j = 0; j < cols; j++) {
                if(land[i][j] == 1) {
                    Integer[] end = dfs(i, j, land, rows, cols);
                    answer.add(new Integer[]{i, j, end[0], end[1]});
                }
            }
        }
        
        int[][] result = new int[answer.size()][4];
        
        for(int i = 0; i < answer.size(); i++) {
            Integer[] group = answer.get(i);
            result[i] = new int[]{group[0], group[1], group[2], group[3]};
        }
        
        return result;
    }
    
    Integer[] dfs(int i, int j, int[][] land, int rows, int cols) {
        if(i < 0 || i >= rows || j < 0 || j >= cols || land[i][j] == 0) {
            return null;
        }
        
        Integer[] res = new Integer[]{i, j};
        
        land[i][j] = 0;
        
        Integer[] right = dfs(i, j + 1, land, rows, cols);
        
        if(right != null) {
            res[1] = right[1];
        }
        
        Integer[] down = dfs(i + 1, j, land, rows, cols);
        
        if(down != null) {
            res[0] = down[0];
        }
        
        return res;
    }
}

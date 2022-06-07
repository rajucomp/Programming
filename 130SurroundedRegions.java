//https://leetcode.com/problems/surrounded-regions/

class Solution {
    
    void checkRow(int rows, int cols, int colIndex, char[][] board, boolean[][] visited) {
        for(int i = 0; i < rows; i++) {
            if(board[i][colIndex] == 'O' && !visited[i][colIndex]) {
                //dfs(i, colIndex, rows, cols, board, visited);
                bfs(i, colIndex, rows, cols, board, visited);
            }
        }
    }
    
    void checkCol(int rows, int cols, int rowIndex, char[][] board, boolean[][] visited) {
        for(int j = 0; j < cols; j++) {
            if(board[rowIndex][j] == 'O' && !visited[rowIndex][j]) {
                //dfs(rowIndex, j, rows, cols, board, visited);
                bfs(rowIndex, j, rows, cols, board, visited);
            }
        }
    }
    
    public void solve(char[][] board) {
        int rows = board.length, cols = board[0].length;
        boolean[][] visited = new boolean[rows][cols];
        checkRow(rows, cols, 0, board, visited);
        checkRow(rows, cols, cols - 1, board, visited);
        checkCol(rows, cols, 0, board, visited);
        checkCol(rows, cols, rows - 1, board, visited);
        
        for(int i = 0; i < rows; i++) {
            for(int j = 0; j < cols; j++) {
                if(board[i][j] == 'O' && !visited[i][j]) {
                    board[i][j] = 'X';
                }
            }
        }
    }
    
    void bfs(int i, int j, int rows, int cols, char[][] board, boolean[][] visited) {
        int[][] directions = new int[][]{
            new int[]{0, 1},
            new int[]{0, -1},
            new int[]{-1, 0},
            new int[]{1, 0}
        };
        
        Queue<Integer[]> queue = new LinkedList();
        queue.offer(new Integer[]{i, j});
        visited[i][j] = true;
        while(!queue.isEmpty()) {
            Integer[] top = queue.poll();
            for(int k = 0; k < directions.length; k++) {
                int x = top[0] + directions[k][0], y = top[1] + directions[k][1];
                
                if(x >= 0 && x < rows && y >= 0 && y < cols && !visited[x][y] && board[x][y] == 'O') {
                    queue.offer(new Integer[]{x, y});
                    visited[x][y] = true;
                }
            }
        }
    }
    
    void dfs(int i, int j, int rows, int cols, char[][] board, boolean[][] visited) {
        if(i < 0 || i >= rows || j < 0 || j >= cols || visited[i][j] || board[i][j] == 'X') {
            return;
        }
        
        visited[i][j] = true;
        dfs(i + 1, j, rows, cols, board, visited);
        dfs(i - 1, j, rows, cols, board, visited);
        dfs(i, j + 1, rows, cols, board, visited);
        dfs(i, j - 1, rows, cols, board, visited);
    }
}

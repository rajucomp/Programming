public class Solution {
    public int solve(int[] A, int B) {
        int n = A.length;
        boolean[][] dp = new boolean[n][B + 1];
        boolean[][] visited = new boolean[n][B + 1];

        return helperTopDownDp(A, n, 0, B, dp, visited) ? 1 : 0;
    }

    boolean helperTopDownDp(int[] A, int n, int index, int sum, boolean[][] dp, boolean[][] visited)
    {   //System.out.println(index + " " + sum);
        if(sum == 0)
        {
            //System.out.println("Found");
            return true;
        }

        if(index == n || sum <= 0)
        {
            return false;
        }


        //System.out.println(A[index] + " " + sum);

        if(!visited[index][sum])
        {
            visited[index][sum] = true;
            if(A[index] <= sum)
            if(helperTopDownDp(A, n, index + 1, sum - A[index], dp, visited))
            {
                dp[index][sum] = true;
                return true;
            }
    
            
        }

        dp[index][sum] = dp[index][sum] || helperTopDownDp(A, n, index + 1, sum, dp, visited);
        return dp[index][sum];
    }
}

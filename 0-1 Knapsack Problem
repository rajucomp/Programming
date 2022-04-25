public class MyClass {

    public int solveKnapsack(int[] profits, int[] weights, int capacity) {
        // TODO: Write your code here

        int n = profits.length;

        int[][] dp = new int[n][capacity + 1];

        //return helper(profits, weights, 0, profits.length, capacity);
        //return helperTopDownDp(profits, weights, 0, n, capacity, dp);
        return bottomUpDp(profits, weights, n, capacity);
    }

    int bottomUpDp(int[] profits, int[] weights, int n, int capacity) {
        int result = 0;


        int[][] dp = new int[n][capacity + 1];

        for (int i = 0; i < n; i++)
            dp[i][0] = 0;

        // if we have only one weight, we will take it if it is not more than the capacity
        for (int c = 0; c <= capacity; c++) {
            if (weights[0] <= c)
                dp[0][c] = profits[0];
        }

        for (int i = 1; i < n; i++) {
            for (int j = 1; j <= capacity; j++) {
                if (weights[i] <= j) {
                    dp[i][j] = Math.max(profits[i] + dp[i - 1][j - weights[i]], dp[i][j]);
                }

                dp[i][j] = Math.max(dp[i - 1][j], dp[i][j]);
            }
        }

        return dp[n - 1][capacity];
    }

    int helperTopDownDp(int[] profits, int[] weights, int index, int n, int capacity, int[][] dp) {
        if (index == n || capacity <= 0 || weights[index] > capacity) {
            return 0;
        }

        if (dp[index][capacity] == 0) {
            int profitIncludingItem = profits[index] + helperTopDownDp(profits, weights, index + 1, n, capacity - weights[index], dp);
            int profitExcludingItem = helperTopDownDp(profits, weights, index + 1, n, capacity, dp);

            dp[index][capacity] = Math.max(profitIncludingItem, profitExcludingItem);
        }

        return dp[index][capacity];
    }

    int helper(int[] profits, int[] weights, int index, int n, int capacity) {

        if (index == n || capacity <= 0 || weights[index] > capacity) {
            return 0;
        }

        return Math.max(
            profits[index] + helper(profits, weights, index + 1, n, capacity - weights[index]),
            helper(profits, weights, index + 1, n, capacity));


    }

    public static void main(String[] args) {
        MyClass ks = new MyClass();
        int[] profits = {
            1,
            6,
            10,
            16
        };
        int[] weights = {
            1,
            2,
            3,
            5
        };
        int maxProfit = ks.solveKnapsack(profits, weights, 7);
        System.out.println("Total knapsack profit ---> " + maxProfit);
        maxProfit = ks.solveKnapsack(profits, weights, 6);
        System.out.println("Total knapsack profit ---> " + maxProfit);
        maxProfit = ks.solveKnapsack(profits, weights, 5);
        System.out.println("Total knapsack profit ---> " + maxProfit);
        maxProfit = ks.solveKnapsack(profits, weights, 1);
        System.out.println("Total knapsack profit ---> " + maxProfit);

    }
}

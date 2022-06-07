//https://leetcode.com/problems/house-robber/


class Solution {
    Map<Integer, Integer> dp = new HashMap<>();
    public int rob(int[] nums) {
        
        //return robBruteForceRecusrive(nums, nums.length - 1);
        //return robTopDownDp(nums, nums.length - 1);
        //return robBottomUpDp(nums);
        return robBottomUpDpSpaceOptimised(nums);
    }
    
    int robBruteForceRecusrive(int[] nums, int index) {
        if(index < 0) {
            return 0;
        }
        
        if(index == 0) {
            return nums[0];
        }
        
        return Math.max(robBruteForceRecusrive(nums, index - 1), nums[index] + robBruteForceRecusrive(nums, index - 2));
    }

    int robTopDownDp(int[] nums, int index) {        
        if(index < 0) {
            return 0;
        }
        
        if(index == 0) {
            return nums[0];
        }
        
        if(!dp.containsKey(index)) {
            dp.put(index, Math.max(robTopDownDp(nums, index - 1), nums[index] + robTopDownDp(nums, index - 2)));
        }
        return dp.get(index);
    }
    
    int robBottomUpDp(int[] nums) {
        int[] dp = new int[nums.length + 1];
        dp[0] = 0;
        dp[1] = nums[0];
        
        for(int i = 1; i < nums.length; i++) {
            dp[i + 1] = Math.max(dp[i], nums[i] + dp[i - 1]);
        }
        
        return dp[nums.length];
    }
    
    int robBottomUpDpSpaceOptimised(int[] nums) {
        int first = 0, second = nums[0];
        
        for(int i = 1; i < nums.length; i++) {
            int curr = Math.max(second, nums[i] + first);
            first = second;
            second = curr;
        }
        return second;
    }
}

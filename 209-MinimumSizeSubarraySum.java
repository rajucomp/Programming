//https://leetcode.com/problems/minimum-size-subarray-sum/submissions/

class Solution {
    
    long[] calculatePrefixSum(int[] nums) {
        int len = nums.length;
        
        long[] prefixSum = new long[len + 1];
    
        for(int i = 1; i <= len; i++) {
            prefixSum[i] = prefixSum[i - 1] + nums[i - 1];
        }
        
        return prefixSum;
    }
    
    int twoPointerSolution(int target, long[] prefixSum, int len) {   
        int left = 0, right = 1, result = len;
        
        while(left <= right && right <= len) {
            if(prefixSum[right] - prefixSum[left] < target)
            {
                right++;
            }
            else
            {
                result = Math.min(result, right - left);
                left++;
            }
        }
        
        return result;
    }
    
    int binarySearchSolution(int target, long[] prefixSum, int len) {
        int result = len;
        
        for(int i = 1; i <= len; i++)
        {
            int minFarIndex = binarySearch(prefixSum[i - 1], i, len, prefixSum, target);
            if(minFarIndex <= len) {
                result = Math.min(result, minFarIndex - i + 1);
            }
        }
        
        return result;
    }
    
    
    int binarySearch(long val, int start, int end, long[] arr, int target)
    {
        while(start <= end)
        {
            int mid = start + (end - start) / 2;
            
            if(arr[mid] - val >= target)
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }
        
        return start;
    }
    
    public int minSubArrayLen(int target, int[] nums) {
        long[] prefixSum = calculatePrefixSum(nums);
        int len = nums.length;
        
        if(prefixSum[len] < target) {
            return 0;
        }
        
        //return twoPointerSolution(target, prefixSum, len);
        return binarySearchSolution(target, prefixSum, len);
    
        
    }
}

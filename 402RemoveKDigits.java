//https://leetcode.com/problems/remove-k-digits/

class Solution {
    public String removeKdigits(String num, int k) {
        ArrayDeque<Character> queue = new ArrayDeque<>();
        
        for(char ch : num.toCharArray())
        {
            while(!queue.isEmpty() && queue.peekFirst() > ch && k > 0)
            {
                queue.removeFirst();
                k--;
            }
            
            queue.addFirst(ch);
            
        }
        
        while(!queue.isEmpty() && k > 0)
        {
            queue.removeFirst();
            k--;
        }
        
        StringBuilder sb = new StringBuilder();
        
        while(!queue.isEmpty() && queue.peekLast() == '0'){
            queue.removeLast();
        }
        
        while(!queue.isEmpty()){
            sb.append(queue.removeLast());
        }
        
        return sb.length() == 0? "0" : sb.toString();
        
    }
}

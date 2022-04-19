/*
// Definition for a Node.
class Node {
    int val;
    Node next;
    Node random;

    public Node(int val) {
        this.val = val;
        this.next = null;
        this.random = null;
    }
}
*/

class Solution {
    
    //Solution with constant space
    Node copyRandomConstant(Node head)
    {
        if(head == null)
        {
            return null;
        }
        
        Node current = head;
        
        while(current != null)
        {
            Node node = new Node(current.val);
            node.next = current.random;
            current.random = node;
            current = current.next;
        }
        
        current = head;
        while(current != null)
        {
            Node random = current.random;
            if(random.next != null)
            {
                random.random = random.next.random;
            }
            
            current = current.next;
        }
        
        current = head;
        Node copyHead = current.random;
     
        while(current != null)
        {
            Node random = current.random.next;
            if(current.next != null)
            {
                current.random.next = current.next.random;
            }
            else
            {
                current.random.next = null;
            }
            current.random = random;
        
            current = current.next;
        }
        
        return copyHead;
    }
    
    //Solution with O(1) extra space
    Node copyRandom(Node head)
    {
        if(head == null)
        {
            return null;
        }
        Node current = head;
        
        //First insert copy notes
        while(current != null)
        {
            Node newNode = new Node(current.val);
            newNode.next = current.next;
            current.next = newNode;
            current = newNode.next;
        }
        
        //Then assign random pointers;
        current = head;
        while(current != null)
        {
            if(current.random != null)
            {
                current.next.random = current.random.next;
            }
            
            current = current.next.next;
        }
        
        Node copyHead = head.next;
        current = head;
        while(current != null)
        {
            
            //Node next = current.next.next;
            Node copy = current.next;
            current.next = current.next.next;
            if(copy.next != null)
            {
                copy.next = copy.next.next;
            }
            
            current = current.next;
            
        }
        
        return copyHead;
        
        
    }
    
    public Node copyRandomList(Node head) {
        
        return copyRandomConstant(head);
        /*
        Node current = head;
        Map<Node, Node> map = new HashMap<>();
        
        while(current != null)
        {   
            map.put(current, new Node(current.val));   
            current = current.next;
        }
        
        current = head;
        
        while(current != null)
        {
            map.get(current).next = map.get(current.next);
            map.get(current).random = map.get(current.random);
            current = current.next;
        }
        
        return map.get(head);
        
        */
    }
}

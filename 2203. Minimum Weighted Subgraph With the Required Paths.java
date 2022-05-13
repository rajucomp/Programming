class Solution {
    class Vertex
    {
        public int value;
        public long weight;
        
        public Vertex(int node, long cost)
        {
            value = node;
            weight = cost;
        }
    }
    
    public long minimumWeight(int n, int[][] edges, int src1, int src2, int dest) {
        Map<Integer, List<Vertex>> graph = new HashMap();
        
        for(int i = 0; i < n; i++)
        {
            graph.putIfAbsent(i, new ArrayList());
        }
        
        for(int i = 0; i < edges.length; i++)
        {
            int src = edges[i][0], destination = edges[i][1], cost = edges[i][2];
            graph.get(src).add(new Vertex(destination, cost));
        }
        
        Map<Integer, Map<Integer, Long>> distanceMap = new HashMap();
        distanceMap.put(src1, djikstra(src1, graph, n));
        distanceMap.put(src2, djikstra(src2, graph, n));
        
        
        
        long first = distanceMap.get(src1).get(src2);
        long second = distanceMap.get(src2).get(src1);
        long third = distanceMap.get(src1).get(dest);
        long fourth = distanceMap.get(src2).get(dest);
        
        long fifth, sixth = Long.MAX_VALUE;
        
        for(Map.Entry<Integer, Long> firstNode : distanceMap.get(src1).entrySet())
        {
            if(distanceMap.get(src2).containsKey(firstNode.getKey()))
            {
                Long secondNode = distanceMap.get(src2).get(firstNode.getKey());
                if(firstNode.getValue() != Long.MAX_VALUE && secondNode != Long.MAX_VALUE)
                {
                    fifth = firstNode.getValue() + secondNode;

                    //System.out.println(firstNode.getKey() + " " + firstNode.getValue());
                    //System.out.println(secondNode.getKey() + " " + secondNode.getValue());

                    long temp = djikstra(firstNode.getKey(), graph, n).get(dest);


                    if(temp != Long.MAX_VALUE)
                    {
                        return fifth + temp;
                    }
                }
            }

        }
        
        //System.out.println(first);
        //System.out.println(second);
        //System.out.println(third);
        //System.out.println(fourth);
        
        //return -1;
        
        if(third != Long.MAX_VALUE)
        {
            if(fourth != Long.MAX_VALUE)
            {
                if(first != Long.MAX_VALUE)
                {
                    if(second != Long.MAX_VALUE)
                    {
                        return Math.min(first + fourth, second + third);
                    }
                    
                    return Math.min(first + fourth, third + fourth);
                }
                
                if(second != Long.MAX_VALUE)
                {
                    return Math.min(second + third, third + fourth);   
                }
                
                return third + fourth;
                
            }
            
            if(second != Long.MAX_VALUE)
            {
                return second + third;
            }
            
            return -1;
        }
        
        if(fourth != Long.MAX_VALUE)
        {
            if(first != Long.MAX_VALUE)
            {
                return first + fourth;
            }

            return -1;
        }
        
        return -1;
    }
    
    Map<Integer, Long> djikstra(int src, Map<Integer, List<Vertex>> graph, int n)
    {
        Map<Integer, Long> distanceMap = new HashMap();
        for(int i = 0; i < n; i++)
        {
           distanceMap.put(i, Long.MAX_VALUE); 
        }
        
        Queue<Vertex> queue = new PriorityQueue<Vertex>((a, b) -> Long.compare(a.weight, b.weight));
        queue.offer(new Vertex(src, 0));
        distanceMap.put(src, 0l);
        
        while(!queue.isEmpty())
        {
            Vertex top = queue.poll();
            
            //System.out.println(top.value);
            
            for(Vertex nei : graph.get(top.value))
            {
                Long a = distanceMap.get(nei.value);
                Long b = distanceMap.get(top.value);
                
                Long c = a + 1;
                if(distanceMap.get(nei.value) > distanceMap.get(top.value) + nei.weight)
                {
                    distanceMap.put(nei.value, distanceMap.get(top.value) + nei.weight);
                    queue.offer(new Vertex(nei.value, distanceMap.get(nei.value)));
                }
            }
        }
        
        return distanceMap;
    }
}

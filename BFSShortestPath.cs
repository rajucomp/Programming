static void Display(List<List<int>> edges)
{
    foreach(var lst in edges)
    {
        Console.WriteLine(lst[0] + " " + lst[1]);
    }
}
    
static Dictionary<int, HashSet<int>> BuildGraph(List<List<int>> edges)
{
    //Display(edges);
    Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();
    
    foreach(var lst in edges)
    {
        if(!graph.ContainsKey(lst[0]))
        {
            graph.Add(lst[0], new HashSet<int>());
        }
        
        if(!graph.ContainsKey(lst[1]))
        {
            graph.Add(lst[1], new HashSet<int>());
        }
        
        graph[lst[0]].Add(lst[1]);
        graph[lst[1]].Add(lst[0]);
    }
    
    return graph;
}

public static List<int> bfs(int n, int m, List<List<int>> edges, int s)
{
    var graph = BuildGraph(edges);
    
    int[] result = new int[n];
    
    bool[] visited = new bool[n];
    
    Queue<int> queue = new Queue<int>();
    
    queue.Enqueue(s);
    visited[s - 1] = true;
    
    while(queue.Count != 0)
    {
        int node = queue.Dequeue();
        
        if(graph.ContainsKey(node))
        {
            foreach(int j in graph[node])
            {
                if(!visited[j - 1])
                {
                    visited[j - 1] = true;
                    queue.Enqueue(j);
                    result[j - 1] = result[node - 1] + 6;
                }
            }
        }
    }
    
    List<int> finalResult = new List<int>();
    
    for(int i = 0; i < result.Length; i++)
    {
        if(i != s - 1)
        {
            finalResult.Add(result[i] == 0 ? -1 : result[i]);
        }
        
    }
    
    return finalResult;
    
}
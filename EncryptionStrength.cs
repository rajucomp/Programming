using System;
using System.Collections.Generic;

class Program
{
    static void Main() {
        int x = 10;
        int y = 25;
        int z = x + y;

        Console.WriteLine("Sum of x + y = "+ z);
        
        //var lst = result(1000, 10000, new List<int>(){2, 4, 8, 2});
        
       // var lst = result(100, 1000, new List<int>(){2, 4});
        
        //var lst = result(200, 2000, new List<int>(){2, 2, 4, 4});
        
        //var lst = result(100, 1000, new List<int>(){1,1,1,1});
        
        var lst = result(9677958, 50058356, new List<int>(){83315, 22089, 19068, 64911, 67636, 4640, 80192, 98971});
        
        foreach(int i in lst)
        {
            Console.WriteLine(i);
        }
    }
    
    static List<int> result(int instructionCount, int validityPeriod, List<int> keys)
    {
        IDictionary<int, int> dict = new Dictionary<int, int>();
        
        foreach(int i in keys)
        {
            if(!dict.ContainsKey(i))
            {
                dict.Add(i, 0);
            }
            dict[i]++;
        }
        
        int maxDegree = 0;
        
        foreach(int i in new HashSet<int>(keys))
        {
            int count = 0;
            for(int j = 2; j * j <= i; j++)
            {
                if(i % j == 0) 
                {
                    if(dict.ContainsKey(j))
                    {
                        count += dict[j];
                    }
                    
                    if((i / j != j) && dict.ContainsKey(i / j))
                    {
                        count += dict[i / j];
                    }
                }
                
                
            }
            count += dict[i];
            //Console.WriteLine(i + "  finalCount " + count);
            
            maxDegree = Math.Max(maxDegree, count);
        }
        
        ulong product = (ulong)(instructionCount * validityPeriod);
        
        Console.WriteLine(maxDegree + "  maxDegree ");
        
        Console.WriteLine(product + "  product ");
        
        
        List<int> answer = new List<int>();
        
        answer.Add((product >= (ulong)(maxDegree * 100000) ? 1 : 0));
        answer.Add(maxDegree * 100000);
        
        return answer;
    }
}
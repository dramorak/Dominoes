// Utility
using System.Collections.Generic;

class Graph
{
    private Dictionary<Object, List<Object>> adj = new Dictionary<Object, List<Object>>();

    public Graph(){}
    public Graph(Object[] vertices, Object[][] edges)
    {
        foreach(var vertex in vertices)
        {
            AddVertex(vertex);
        }

        foreach(Object[] edge in edges)
        {
            AddEdge(edge[0], edge[1]);
        }
    }

    public void AddEdge(Object source, Object dest)
    {
        // adj[source].append(dest)
        if(adj.ContainsKey(source))
        {
            adj[source].Add(dest);
        }
        else
        {
            adj[source] = new List<Object>(){dest};
        }
    }

    public void AddVertex(Object v)
    {
        adj[v] = new List<Object>(){};
    }

    private int NumEdges 
    {
        get
        {
            int num = 0;
            foreach(var keyVal in adj)
            {
                num += keyVal.Value.Count;
            }
            return num;
        }
    }

    ///<summary>
    /// Returns the longest path in Graph starting from source.
    ///</summary>
    public List<Object> LongestPath(Object source)
    {
        
        //recursively

        // The longest path from source is equal to the the max of the longest paths from each of the neighbouring
        // vertices (with the travelled edge "blackened" - visited.)
        //
        // I can't blacken edges in the same way, but I can carry a dictionary of edges that contains information on
        // visits
        //
        //  What would the runtime be?
        //      - Large
        //      - How large?
        //      - Seriously, how large
        //      Approx (Average out-edges) ** num_edges
        //       (e / v) ** e
        //       = O(e ** e)
        //       potentially v ** (v ** 2), which is so bad it's not even worth considering. Look at the dominoes,
        //       v = 13
        //       e = 16
        //       (16/13) ** 16 = 27 ...
        //       Actually not bad for small sets ... 
        //  Wikipedia says that the longest paths problem is NP hard, so I guess I'll just brute force it.

        // if 0 neighbors, return []
        if (adj[source].Count == 0)
        {
            return new List<Object>(){source};
        }
        // else, for each neighbor in adj[source]
        List<Object> bestFound = new List<Object>(){};
        List<Object> copy = new List<Object>(){};
        foreach(var neighbor in adj[source])
        {
            copy.Add(neighbor);
        }
        foreach(var neighbor in copy)
        {

        //    -delete neighbor from adj[source] (since we can't use the same edge twice)
            adj[source].Remove(neighbor); //NOTETOSELF more efficiently implemented with dictionary.

        //    -find LongestPath(neighbor)
            List<Object> L = LongestPath(neighbor);

        //    -if LongestPath(neighbor).Count is greater then best found, replace
            bestFound = L.Count > bestFound.Count ? L : bestFound;

        //    -fill in gap again.
            adj[source].Add(neighbor);
        }
        bestFound.Add(source);
        return bestFound;
    }

    public override string ToString()
    {
        string result = "";
        foreach(var keyValPair in adj)
        {
            result += $"{keyValPair.Key}:";
            foreach(var val in keyValPair.Value)
            {
                result += $"{val} ";
            }
            
            result += "\n";
        }
        return result;
    }
}

static class UtilityFunctions
{
    //why do I need to make a class for this god why
    
    ///<summary>
    /// Displays a generic List 
    ///</summary>
    public static void Display(List<Object> l)
    {
        int c = 1;
        foreach(var obj in l)
        {
            if (c < l.Count)
            {
                Console.Write($"{obj}, ");
            }
            else
            {
                Console.WriteLine($"{obj}");
            }
            
        }
    }
}

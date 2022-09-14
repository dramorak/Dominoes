// Utility
using System.Collections.Generic;
using System;
class Graph
{
    private Dictionary<object, List<object>> adj = new Dictionary<object, List<object>>();

    public Graph(){}
    public Graph(object[] vertices, object[][] edges)
    {
        foreach(var vertex in vertices)
        {
            AddVertex(vertex);
        }

        foreach(object[] edge in edges)
        {
            AddEdge(edge[0], edge[1]);
        }
    }
    public Graph(int n)
    {
        // initializes graph with n vertices (0 to n - 1)

        for(int i = 0; i < n; i++)
        {
            AddVertex(i);
        }
    }

    public void AddEdge(object source, object dest)
    {
        // adj[source].append(dest)
        if(adj.ContainsKey(source))
        {
            adj[source].Add(dest);
        }
        else
        {
            adj[source] = new List<object>(){dest};
        }
    }

    public void DeleteEdge(object source, object dest)
    {
        adj[source].Remove(dest);
        return;
    }
    
    public void AddVertex(object v)
    {
        adj[v] = new List<object>(){};
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
    public List<object> LongestPath(object source)
    {

        // if 0 neighbors, return []
        if (adj[source].Count == 0)
        {
            return new List<object>(){source};
        }
        // else, for each neighbor in adj[source]
        List<object> bestFound = new List<object>(){};
        List<object> copy = new List<object>(){};
        foreach(var neighbor in adj[source])
        {
            copy.Add(neighbor);
        }
        foreach(var neighbor in copy)
        {

        //    -delete neighbor from adj[source] (since we can't use the same edge twice)
            adj[source].Remove(neighbor); //NOTETOSELF more efficiently implemented with dictionary.

        //    -find LongestPath(neighbor)
            List<object> L = LongestPath(neighbor);

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
    public static void Display(List<object> l)
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

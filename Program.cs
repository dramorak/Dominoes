using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        Graph g = new Graph();
        g.AddVertex(1);
        g.AddVertex(2);
        g.AddVertex(3);
        g.AddVertex(4);
        g.AddEdge(1,2);
        g.AddEdge(2,3);
        g.AddEdge(3,4);
        g.AddEdge(1,4);
        g.AddEdge(4,2);

        UtilityFunctions.Display(g.LongestPath(1));
    }
}
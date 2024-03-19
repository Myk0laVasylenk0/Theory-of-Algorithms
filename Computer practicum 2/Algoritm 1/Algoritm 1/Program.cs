using System;
using System.Collections.Generic;



public class Graph
{
    private int V;
    private List<List<(int, int)>> adj;

    public Graph(int V)
    {
        this.V = V;
        adj = new List<List<(int, int)>>();

        for (int i = 0; i < V; i++)
        {
            adj.Add(new List<(int, int)>());
        }
    }

    public void AddEdge(int u, int v, int w)
    {
        adj[u].Add((v, w));
        adj[v].Add((u, w)); // Assuming the graph is undirected
    }

    public void ShortestPath(int src)
    {
        PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();
        pq.Enqueue((src, 0), 0);

        int[] dist = new int[V];
        Array.Fill(dist, int.MaxValue);
        dist[src] = 0;

        int[] parent = new int[V];
        Array.Fill(parent, -1);
        parent[src] = src;

        while (pq.Count > 0)
        {
            var (u, _) = pq.Dequeue();

            foreach (var (v, weight) in adj[u])
            {
                if (dist[v] > dist[u] + weight)
                {
                    dist[v] = dist[u] + weight;
                    pq.Enqueue((v, dist[v]), dist[v]);
                    parent[v] = u;
                }
            }
        }

        for (int i = 0; i < V; i++)
        {
            if (i != src)
            {
                Console.WriteLine($"The minimum distance from {src} to {i} = {dist[i]}. " + GetPath(parent, i));
            }
        }
    }

    private string GetPath(int[] parent, int j)
    {
        if (parent[j] == j)
        {
            return j.ToString();
        }

        return GetPath(parent, parent[j]) + "->" + j.ToString();
    }

    // Driver's code
    public static void Main(string[] args)
    {

        var watch = System.Diagnostics.Stopwatch.StartNew();

        int V = 12;
        Graph g = new Graph(V);

        // Making the graph
        g.AddEdge(0, 7, 1200);
        g.AddEdge(4, 7, 4700);
        g.AddEdge(4, 9, 1300);
        g.AddEdge(1, 4, 900);
        g.AddEdge(1, 5, 1600);
        g.AddEdge(1, 8, 950);
        g.AddEdge(8, 5, 1100);
        g.AddEdge(9, 5, 650);
        g.AddEdge(2, 5, 1000);
        g.AddEdge(3, 5, 500);
        g.AddEdge(5, 10, 950);
        g.AddEdge(2, 3, 600);
        g.AddEdge(2, 6, 600);
        g.AddEdge(2, 11, 600);
        g.AddEdge(6, 10, 750);

        g.ShortestPath(11);

        

        Console.WriteLine("\n");
        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;
        Console.WriteLine(elapsedMs + "ms");

        Console.ReadKey();

    }
}



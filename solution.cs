Here is a C# console application that determines the critical connections (bridges) in a network using Depth-First Search (DFS) algorithm.

```C#
using System;
using System.Collections.Generic;

public class Program
{
    private static int time = 0;
    private static List<List<int>> criticalConnections;
    private static int[] low;
    private static int[] ids;
    private static bool[] visited;
    private static List<int>[] graph;

    public static void Main()
    {
        int n = 4;
        List<List<int>> connections = new List<List<int>>
        {
            new List<int> {0, 1},
            new List<int> {1, 2},
            new List<int> {2, 0},
            new List<int> {1, 3}
        };

        criticalConnections = CriticalConnections(n, connections);

        foreach (var connection in criticalConnections)
        {
            Console.WriteLine(string.Join(" ", connection));
        }
    }

    public static List<List<int>> CriticalConnections(int n, List<List<int>> connections)
    {
        low = new int[n];
        ids = new int[n];
        visited = new bool[n];
        graph = new List<int>[n];
        criticalConnections = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<int>();
        }

        foreach (var connection in connections)
        {
            graph[connection[0]].Add(connection[1]);
            graph[connection[1]].Add(connection[0]);
        }

        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                Dfs(i, -1);
            }
        }

        return criticalConnections;
    }

    private static void Dfs(int at, int parent)
    {
        visited[at] = true;
        low[at] = ids[at] = ++time;

        foreach (var to in graph[at])
        {
            if (to == parent) continue;
            if (!visited[to])
            {
                Dfs(to, at);
                low[at] = Math.Min(low[at], low[to]);
                if (ids[at] < low[to])
                {
                    criticalConnections.Add(new List<int> { at, to });
                }
            }
            else
            {
                low[at] = Math.Min(low[at], ids[to]);
            }
        }
    }
}
```

This program determines the critical connections in a network. It uses the Depth-First Search (DFS) algorithm to traverse the network and find the bridges. The bridges are the edges that if removed, would increase the number of connected components in the graph. These are the critical connections in the network.
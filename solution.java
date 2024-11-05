Here is a Java console application that determines the critical connections (bridges) in a network:

```java
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Main {
    static int time = 0;

    public static void main(String[] args) {
        int n = 4;
        List<List<Integer>> connections = new ArrayList<>();
        connections.add(Arrays.asList(0, 1));
        connections.add(Arrays.asList(1, 2));
        connections.add(Arrays.asList(2, 0));
        connections.add(Arrays.asList(1, 3));
        System.out.println(criticalConnections(n, connections));
    }

    public static List<List<Integer>> criticalConnections(int n, List<List<Integer>> connections) {
        int[] disc = new int[n], low = new int[n];
        List<Integer>[] graph = new ArrayList[n];
        List<List<Integer>> res = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            graph[i] = new ArrayList<>();
        }
        for (int i = 0; i < connections.size(); i++) {
            int from = connections.get(i).get(0), to = connections.get(i).get(1);
            graph[from].add(to);
            graph[to].add(from);
        }
        boolean[] visited = new boolean[n];
        for (int i = 0; i < n; i++) {
            if (!visited[i])
                dfs(i, low, disc, graph, res, visited, i);
        }
        return res;
    }

    private static void dfs(int u, int[] low, int[] disc, List<Integer>[] graph, List<List<Integer>> res, boolean[] visited, int pre) {
        visited[u] = true;
        disc[u] = low[u] = ++time;
        for (int v : graph[u]) {
            if (v == pre) continue;
            if (!visited[v]) {
                dfs(v, low, disc, graph, res, visited, u);
                low[u] = Math.min(low[u], low[v]);
                if (low[v] > disc[u]) {
                    res.add(Arrays.asList(u, v));
                }
            } else {
                low[u] = Math.min(low[u], disc[v]);
            }
        }
    }
}
```

This program uses depth-first search to find the bridges in the network. It keeps track of the discovery time of each node and the lowest discovery time of any node that can be reached from the current node. If the lowest discovery time of a connected node is greater than the discovery time of the current node, then the connection to that node is a bridge.
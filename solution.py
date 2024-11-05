Here is a Python solution using Depth-First Search (DFS) algorithm to find the critical connections (bridges) in a network.

```python
from collections import defaultdict

class Solution:
    def __init__(self):
        self.id = 0
        self.ids = defaultdict(int)
        self.low = defaultdict(int)
        self.visited = defaultdict(bool)
        self.bridges = []
        self.adj_list = defaultdict(list)

    def criticalConnections(self, n, connections):
        self.build_adj_list(n, connections)
        self.dfs(0, -1)
        return self.bridges

    def build_adj_list(self, n, connections):
        for i in range(n):
            self.adj_list[i] = []
        for connection in connections:
            self.adj_list[connection[0]].append(connection[1])
            self.adj_list[connection[1]].append(connection[0])

    def dfs(self, at, parent):
        self.visited[at] = True
        self.low[at] = self.id
        self.ids[at] = self.id
        self.id += 1

        for to in self.adj_list[at]:
            if to == parent:
                continue
            if not self.visited[to]:
                self.dfs(to, at)
                self.low[at] = min(self.low[at], self.low[to])
                if self.ids[at] < self.low[to]:
                    self.bridges.append([at, to])
            else:
                self.low[at] = min(self.low[at], self.ids[to])

if __name__ == "__main__":
    s = Solution()
    print(s.criticalConnections(4, [[0, 1], [1, 2], [2, 0], [1, 3]]))
```

This Python program will find the critical connections (bridges) in a network. The input to the `criticalConnections` function is the number of nodes in the network and a list of connections between the nodes. The function will return a list of all the critical connections in the network.
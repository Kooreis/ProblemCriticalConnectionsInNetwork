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
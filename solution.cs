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

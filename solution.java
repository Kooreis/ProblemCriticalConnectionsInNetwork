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
namespace Lab2;

public static class ResultOutput
{
    public static void PrintResult(Stack<State> route)
    {
        int routeLength = route.Count - 1;
        if (routeLength == 0) {
            Console.WriteLine("Puzzle solution not found!");
            Environment.Exit(1);
        }
        while (route.Count != 0)
        {
            Console.WriteLine(route.Pop());
        }
        Console.WriteLine($"Route length is {routeLength}.");
    }

    public static void PrintStatistics()
    {
        Console.WriteLine("Search time: "+ Measurement.Stopwatch.ElapsedMilliseconds+" milliseconds");
        Console.WriteLine("Iterations: " + Measurement.Iterations);
        Console.WriteLine("Dead ends: " + Measurement.DeadEnds);
        Console.WriteLine("Amount of states: " + Measurement.AmountOfStates);
        Console.WriteLine("Amount of states in memory: " + Measurement.AmountOfStatesInMemory);
    }
}
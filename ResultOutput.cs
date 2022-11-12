namespace Lab2;

public static class ResultOutput
{
    public static void PrintResult(Stack<State> route)
    {
        int routeLength = route.Count - 1;
        if (routeLength == 0) {
            Console.WriteLine("Path not found!");
            Environment.Exit(1);
        }
        while (route.Count != 0)
        {
            Console.WriteLine(route.Pop());
        }
        Console.WriteLine($"Route length is {routeLength}.");
    }
}
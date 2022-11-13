namespace Lab2;

public abstract class PathSearcher
{
    protected static readonly int goal = 123456789;
    public Stack<State> TraceRoute(Node? node)
    {
        Stack<State> route = new Stack<State>();
        while (node is not null)
        {
            route.Push(node.State);
            node = node.Previous;
        }

        return route;
    }

    public abstract Node? Solve(State startState);

}
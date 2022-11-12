namespace Lab2;

public class AStar
{
    private static readonly State goal = new State(new int[][]{new []{1, 2, 3}, new []{4, 5, 6}, new []{7, 8, 9}});
    public static Node? Solve(State startState)
    {
        Node startNode = new Node(startState, 0, null);
        HashSet<int> closedStates = new HashSet<int>();
        PriorityQueue<Node, int> openStates = new PriorityQueue<Node, int>();
        openStates.Enqueue(startNode, 0);
        while (openStates.Count != 0)
        {
            Node current = openStates.Dequeue();
            if (closedStates.Contains(current.State.Hash)) continue;
            closedStates.Add(current.State.Hash);
            if (current.State.Equals(goal)) return current;
            State[] children = current.State.GetChildren();
            foreach (State nextState in children)
            {
                if (closedStates.Contains(nextState.Hash)) continue;
                openStates.Enqueue(new Node(nextState, current.Depth + 1, current),
                    nextState.ManhattanDistance + current.Depth + 1);
            }
        }

        return null;
    }

    public static Stack<State> TraceRoute(Node? node)
    {
        Stack<State> route = new Stack<State>();
        while (node is not null)
        {
            route.Push(node.State);
            node = node.Previous;
        }

        return route;
    }
}
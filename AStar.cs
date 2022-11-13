namespace Lab2;

public class AStar : PathSearcher
{
    public override Node? Solve(State startState)
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
            if (current.State.Hash==goal) return current;
            foreach (State nextState in current.State.GetChildren())
            {
                if (closedStates.Contains(nextState.Hash)) continue;
                openStates.Enqueue(new Node(nextState, current.Depth + 1, current),
                    nextState.ManhattanDistance + current.Depth + 1);
            }
        }

        return null;
    }

}
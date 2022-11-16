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
            if (Measurement.TimeAndMemoryConstraintIsViolated())
            {
                Measurement.DeadEnds++;
                return null;
            }
            Measurement.Iterations++;
            Node current = openStates.Dequeue();
            if (closedStates.Contains(current.State.Field)) continue;
            closedStates.Add(current.State.Field);
            if (current.State.Field==goal) return current;
            bool isDeadEnd = true;
            foreach (State nextState in current.State.GetChildren())
            {
                if (closedStates.Contains(nextState.Field)) continue;
                openStates.Enqueue(new Node(nextState, (byte)(current.Depth + 1), current),
                    nextState.GetManhattanDistance() + current.Depth + 1);
                isDeadEnd = false;
            }

            if (isDeadEnd) Measurement.DeadEnds++;
            Measurement.AmountOfStatesInMemory = Math.Max(closedStates.Count + openStates.Count, Measurement.AmountOfStatesInMemory);
        }

        return null;
    }

}
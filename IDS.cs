namespace Lab2;

public class IDS : PathSearcher
{
    public override Node? Solve(State startState)
    {
        bool cutoffOccurred = true;
        Node startNode = new Node(startState, 0, null);
        Node? result = null;
        int limit;
        for (limit = 0; cutoffOccurred; limit++)
        {
            Console.Write("Searching on depth of " + limit + "\r");
            (result, cutoffOccurred) = RecursiveDepthLimitedSearch(startNode, limit);
        }

        Measurement.AmountOfStatesInMemory = result is null? limit : result.Depth + 2;
        return result;
    }

    private (Node?, bool) RecursiveDepthLimitedSearch(Node node, int depth)
    {
        if (Measurement.TimeAndMemoryConstraintIsViolated())
        {
            Measurement.DeadEnds++;
            return (null, false);
        }
        Measurement.Iterations++;
        if (node.State.Field == goal) return (node, false);
        bool cutoffOccurred = false;
        if (depth == node.Depth)
        {
            Measurement.DeadEnds++;
            return (null, true);
        }
        foreach (Node childNode in node.GetChildren())
        {
            (Node?, bool) result = RecursiveDepthLimitedSearch(childNode, depth);
            if (result.Item2) cutoffOccurred = true;
            if (result.Item1 is not null) return result;
        }

        return (null, cutoffOccurred);
    }
}
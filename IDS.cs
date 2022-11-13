using System.Diagnostics;

namespace Lab2;

public class IDS : PathSearcher
{
    public override Node? Solve(State startState)
    {
        bool cutoffOccurred = true;
        Node startNode = new Node(startState, 0, null);
        Node? result = null;
        for (int limit = 0; cutoffOccurred; limit++)
        {
            Console.Write("Searching on depth of "+limit+"\r");
            (result, cutoffOccurred) = RecursiveDepthLimitedSearch(startNode, limit);
            GC.Collect();
        }

        return result;
    }

    private (Node?, bool) RecursiveDepthLimitedSearch(Node node, int depth)
    {
        bool cutoffOccurred = false;
        if (node.State.Hash==goal) return (node, false);
        if (depth == node.Depth) return (null, true);
        foreach (Node childNode in node.GetChildren())
        {
            (Node?, bool) result = RecursiveDepthLimitedSearch(childNode, depth);
            if (result.Item2) cutoffOccurred = true;
            if (result.Item1 is not null) return result;
        }

        return (null, cutoffOccurred);
    }
}
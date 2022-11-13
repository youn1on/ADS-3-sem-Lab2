namespace Lab2;

public class Node
{
    public State State;
    public byte Depth;
    public Node? Previous;

    public Node(State state, byte depth, Node? previous)
    {
        State = state;
        Depth = depth;
        Previous = previous;
    }

    public IEnumerable<Node> GetChildren()
    {
        foreach (State state in State.GetChildren())
        {
            if (Previous is not null && Previous.State.Equals(state)) continue;
            yield return new Node(state, (byte)(Depth + 1), this);
        }
    }

}
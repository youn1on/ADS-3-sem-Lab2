namespace Lab2;

public class Node
{
    public State State;
    public int Depth;
    public Node? Previous;

    public Node(State state, int depth, Node previous)
    {
        State = state;
        Depth = depth;
        Previous = previous;
    }

}
namespace Lab2;

public struct State
{
    public int[][] Field { get; }
    public int ManhattanDistance { get; }

    public State(int[][] field)
    {
        Field = field;
        ManhattanDistance = GetManhattanDistance(field);
    }

    public int[] ToSequence()
    {
        int[] sequence = new int[9];
        for (int i = 0; i < 3; i++)
        {
            Field[i].CopyTo(sequence, i*3);
        }

        return sequence;
    }
    
    private static int GetManhattanDistance(int[][] field)
    {
        int manhattanDistance = 0;
        for (int i = 0; i < field.Length; i++)
        {
            for (int j = 0; j < field[0].Length; j++)
            {
                int value = field[i][j];
                manhattanDistance += Math.Abs(i - (value - 1) / 3) + Math.Abs(j - (value - 1) % 3);
            }
        }

        return manhattanDistance;
    }

    public bool Equals(State state)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (Field[i] != state.Field[i]) return false;
            }
        }

        return true;
    }

    public State[] GetChildren()
    {
        throw new NotImplementedException();
    }
}
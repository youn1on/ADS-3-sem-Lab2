namespace Lab2;

public struct State
{
    public byte ManhattanDistance { get; }
    public int Field { get; }

    public State(int field)
    {
        ManhattanDistance = GetManhattanDistance(field);
        Field = field;
    }

    public int[] ToSequence()
    {
        int[] sequence = new int[9];
        int source = Field;
        for (int i = 8; i >= 0; i--, source /= 10)
        {
            sequence[i] = source % 10;
        }

        return sequence;
    }

    private static byte GetManhattanDistance(int field)
    {
        byte manhattanDistance = 0;
        for (int source = field, i = 8; i > 0; i--, source /= 10)
        {
            int value = source % 10;
            if (value == 9) continue;
            manhattanDistance += (byte)(Math.Abs(i/3 - (value - 1) / 3) + Math.Abs(i%3 - (value - 1) % 3));
        }

        return manhattanDistance;
    }

    public bool Equals(State state)
    {
        return Field == state.Field;
    }

    public IEnumerable<State> GetChildren()
    {
        byte freeIndex;
        if (!TryFindFreeCell(out freeIndex))
            throw new ApplicationException("Invalid field structure");
        foreach (byte moveIndex in GetPossibleMoves(freeIndex))
        {
            yield return MakeMove(freeIndex, moveIndex);
        }
    }

    private bool TryFindFreeCell(out byte index)
    {
        int source = Field;
        for (index = 8; index < 9; index--, source /= 10)
        {
            if (source % 10 == 9) return true;
        }

        return false;
    }

    private static IEnumerable<byte> GetPossibleMoves(byte freeIndex)
    {
        if (freeIndex < 6) yield return (byte)(freeIndex+3);
        if (freeIndex > 2) yield return (byte)(freeIndex-3);
        if (freeIndex % 3 < 2) yield return (byte)(freeIndex+1);
        if (freeIndex % 3 > 0) yield return (byte)(freeIndex-1);
    }

    private State MakeMove(int freeIndex, int moveIndex)
    {
        int source = Field;
        int freeIndexMultiplier = (int)Math.Pow(10, 8 - freeIndex);
        int moveIndexMultiplier = (int)Math.Pow(10, 8 - moveIndex);
        int number = source % (moveIndexMultiplier * 10) / moveIndexMultiplier;
        source -= 9 * freeIndexMultiplier;
        source += number * freeIndexMultiplier;
        source -= number * moveIndexMultiplier;
        source += 9 * moveIndexMultiplier;

        return new State(source);
    }
    
    public override string ToString()
    {
        string result = "";
        string source = Field.ToString();
        byte ind;
        for (byte i = 0; i < 3; i++)
        {
            for (byte j = 0; j < 3; j++)
            {
                ind = (byte)(i * 3 + j);
                if (source[ind] == '9') result += "_ ";
                else result += source[ind] + " ";
            }

            result += "\n";
        }
        return result;
    }
}
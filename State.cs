namespace Lab2;

public struct State
{
    private byte[][] Field { get; }
    public int ManhattanDistance { get; }
    public int Hash { get; }

    public State(byte[][] field)
    {
        Field = field;
        ManhattanDistance = GetManhattanDistance(field);
        Hash = GetHash(field);
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
    
    private static int GetManhattanDistance(byte[][] field)
    {
        int manhattanDistance = 0;
        for (int i = 0; i < field.Length; i++)
        {
            for (int j = 0; j < field[0].Length; j++)
            {
                int value = field[i][j];
                if (value == 9) continue;
                manhattanDistance += Math.Abs(i - (value - 1) / 3) + Math.Abs(j - (value - 1) % 3);
            }
        }

        return manhattanDistance;
    }

    public bool Equals(State state)
    {
        return Hash == state.Hash;
    }

    // public State[] GetChildren()
    // {
    //     int freeI, freeJ;
    //     if (!TryFindFreeCell(out freeI, out freeJ))
    //         throw new ApplicationException("Invalid field structure");
    //     List<(int, int)> moves = GetPossibleMoves(freeI, freeJ);
    //     State[] children = new State[moves.Count];
    //
    //     for (int i = 0; i < moves.Count; i++)
    //     {
    //         children[i] = MakeMove(freeI, freeJ, moves[i]);
    //     }
    //
    //     return children;
    // }
    
    public IEnumerable<State> GetChildren()
    {
        int freeI, freeJ;
        if (!TryFindFreeCell(out freeI, out freeJ))
            throw new ApplicationException("Invalid field structure");
        foreach (var move in GetPossibleMoves(freeI, freeJ))
        {
            yield return MakeMove(freeI, freeJ, move);
        }
    }

    private bool TryFindFreeCell(out int i, out int j)
    {
        for (i = 0; i < 3; i++)
        {
            for (j = 0; j < 3; j++)
            {
                if (Field[i][j] == 9) return true;
            }
        }
        
        i = j = -1;
        return false;
    }
    
    // private static List<(int, int)> GetPossibleMoves(int freeI, int freeJ)
    // {
    //     List<(int, int)> moves = new List<(int, int)>();
    //     if (freeI < 2) moves.Add((freeI+1, freeJ));
    //     if (freeI > 0) moves.Add((freeI-1, freeJ));
    //     if (freeJ < 2) moves.Add((freeI, freeJ+1));
    //     if (freeJ > 0) moves.Add((freeI, freeJ-1));
    //     return moves;
    // }
    
    private static IEnumerable<(int, int)> GetPossibleMoves(int freeI, int freeJ)
    {
        if (freeI < 2) yield return (freeI+1, freeJ);
        if (freeI > 0) yield return (freeI-1, freeJ);
        if (freeJ < 2) yield return (freeI, freeJ+1);
        if (freeJ > 0) yield return (freeI, freeJ-1);
    }

    private State MakeMove(int freeI, int freeJ, (int, int) move)
    {
        byte[][] newField = new byte[3][];
        for (int i = 0; i < 3; i++)
        {
            newField[i] = new byte[3];
            Field[i].CopyTo(newField[i], 0);
        }

        (newField[freeI][freeJ], newField[move.Item1][move.Item2]) =
            (newField[move.Item1][move.Item2], newField[freeI][freeJ]);

        return new State(newField);
    }

    public override string ToString()
    {
        string result = "";
        for (int i = 0; i < Field.Length; i++)
        {
            for (int j = 0; j < Field[i].Length; j++)
            {
                if (Field[i][j] == 9) result += "_ ";
                else result += Field[i][j] + " ";
            }

            result += "\n";
        }
        return result;
    }

    public static int GetHash(byte[][] field)
    {
        int hash = 0;

        for (int i = 0; i < field.Length; i++)
        {
            for (int j = 0; j < field[0].Length; j++)
            {
                hash *= 10;
                hash += field[i][j];
            }
        }
        
        return hash;
    }
}
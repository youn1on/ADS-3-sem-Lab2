namespace Lab2;

public struct State
{
    public int[][] Field { get; }
    public int ManhattanDistance { get; }

    public int Hash;

    public State(int[][] field)
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
    
    private static int GetManhattanDistance(int[][] field)
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
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (Field[i][j] != state.Field[i][j]) return false;
            }
        }

        return true;
    }

    public State[] GetChildren()
    {
        int freeI, freeJ;
        if (!TryFindFreeCell(out freeI, out freeJ))
            throw new ApplicationException("Invalid field structure");
        List<(int, int)> moves = GetPossibleMoves(freeI, freeJ);
        State[] children = new State[moves.Count];

        for (int i = 0; i < moves.Count; i++)
        {
            children[i] = MakeMove(freeI, freeJ, moves[i]);
        }

        return children;
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
    
    private static List<(int, int)> GetPossibleMoves(int freeI, int freeJ)
    {
        List<(int, int)> moves = new List<(int, int)>();
        if (freeI < 2) moves.Add((freeI+1, freeJ));
        if (freeI > 0) moves.Add((freeI-1, freeJ));
        if (freeJ < 2) moves.Add((freeI, freeJ+1));
        if (freeJ > 0) moves.Add((freeI, freeJ-1));
        return moves;
    }

    private State MakeMove(int freeI, int freeJ, (int, int) move)
    {
        int[][] newField = new int[3][];
        for (int i = 0; i < 3; i++)
        {
            newField[i] = new int[3];
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

    public static int GetHash(int[][] field)
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
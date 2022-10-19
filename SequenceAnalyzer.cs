namespace Lab2;

public static class SequenceAnalyzer
{
    public static int CountInversions(int[] sequence)
    {
        if (!IsValidSequence(sequence)) throw new ArgumentException("Invalid sequence.");
        int inversionsNumber = 0;
        for (int i = 0; i < sequence.Length; i++)
        {
            if (sequence[i] is 9) continue;
            for (int j = i+1; j < sequence.Length; j++)
            {
                if (sequence[i] > sequence[j]) inversionsNumber++;
            }
        }
        return inversionsNumber;
    }

    public static bool IsValidSequence(int[] sequence)
    {
        if (sequence.Length != 9) return false;
        HashSet<int> elements = new HashSet<int>();
        foreach (int element in sequence) 
        {
            if (element is < 1 or > 9 || elements.Contains(element))
            {
                return false;
            }

            elements.Add(element);
        }
        return true;
    }

    public static bool IsSolvable(int[] sequence)
    {
        return CountInversions(sequence) % 2 == 0;
    }
    
    public static bool IsSolvable(int[][] state)
    {
        int[] sequence = new int[9];
        for (int i = 0; i < 3; i++)
        {
            state[i].CopyTo(sequence, i*3);
        }

        return IsSolvable(sequence);
    }
}
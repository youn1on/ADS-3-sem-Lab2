namespace Lab2;

public static class PuzzleGenerator
{
    public static void GenerateFile(string filename, bool isSolvable = true)
    {
        StreamWriter sw = new StreamWriter(filename, false);
        int[] sequence = GenerateSequence(isSolvable);
        for (int i = 0; i < sequence.Length; i++)
        {
            sw.Write((sequence[i] == 9? "_" : sequence[i]) + (i%3 == 2? "\n" : " "));
        }
        sw.Close();
    }

    public static int[] GenerateSequence(bool isSolvable)
    {
        int[] sequence = new int[9];
        List<int> source = new List<int>();
        Random rand = new Random();
        int index;
        for (int i = 1; i <= 9; i++)
        {
            source.Add(i);
        }

        for (int i = 0; i < sequence.Length; i++)
        {
            index = rand.Next(source.Count);
            sequence[i] = source[index];
            source.RemoveAt(index);
        }

        if (SequenceAnalyzer.IsSolvable(sequence) != isSolvable)
        {
            (sequence[8], sequence[7]) = (sequence[7], sequence[8]);
        }

        return sequence;
    }
    
}
    
    
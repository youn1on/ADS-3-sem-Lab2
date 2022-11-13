namespace Lab2;

public static class StartStateFactory
{
    public static State GetStartState(string filename)
    {
        byte[][] field = new byte[3][];
        string content = File.ReadAllText(filename);
        string[] lines = content.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < lines.Length; i++)
        {
            field[i] = new byte[3];
            string[] numbers = lines[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < numbers.Length; j++)
            {
                field[i][j] = numbers[j] == "_" ? (byte)9 : byte.Parse(numbers[j]);
            }
        }

        return new State(field);
    }

    
}
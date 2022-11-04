namespace Lab2;

public static class StartStateFactory
{
    public static State GetStartState(string filename)
    {
        int[][] field = new int[3][];
        string content = File.ReadAllText(filename);
        string[] lines = content.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < lines.Length; i++)
        {
            field[i] = new int[3];
            string[] numbers = lines[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < numbers.Length; j++)
            {
                field[i][j] = int.Parse(numbers[j]);
            }
        }

        return new State(field);
    }

    
}
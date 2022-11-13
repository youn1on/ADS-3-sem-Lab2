namespace Lab2;

public static class StartStateFactory
{
    public static State GetStartState(string filename)
    {
        string content = File.ReadAllText(filename);
        string[] lines = content.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        int field = 0;
        foreach (string line in lines)
        {
            string[] numbers = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (string number in numbers)
            {
                field *= 10;
                field += number == "_" ? 9 : int.Parse(number);
            }
        }

        return new State(field);
    }

    
}
namespace Lab2;

public class UserInput
{
    public static string GetFilename()
    {
        while (true)
        {
            Console.WriteLine("Enter your filename");
            string filename = Console.ReadLine();
            if (File.Exists(filename) && Validator.IsValidFile(filename)) return filename;
            Console.WriteLine("Such file doesn't exist or has invalid structure! Please, select another file.");
        }
    }

    public static bool WantToSelectFile()
    {
        ConsoleKey key;
        while (true)
        {
            Console.WriteLine("Do you want to select existing file or generate a new one? " +
                              "Press 's' to select and 'g' to generate");
            key = Console.ReadKey().Key;
            Console.Write("\r");
            if (key == ConsoleKey.S) return true;
            if (key == ConsoleKey.G) return false;
            Console.WriteLine("Invalid key pressed");
        }
       
    }

    public static bool AStarSelected()
    {
        ConsoleKey key;
        while (true)
        {
            Console.WriteLine("Do you want to select A* or IDS? " +
                              "Press 'a' to choose A* and 'i' to select IDS");
            key = Console.ReadKey().Key;
            Console.Write("\r");
            if (key == ConsoleKey.A) return true;
            if (key == ConsoleKey.I) return false;
            Console.WriteLine("Invalid key pressed");
        }
    }
}
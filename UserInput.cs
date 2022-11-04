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
}
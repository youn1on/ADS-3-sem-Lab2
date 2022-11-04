using System.Reflection;
using System.Text.RegularExpressions;

namespace Lab2;

public class Validator
{
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

    public static bool IsValidFile(string filename)
    {
        string content = File.ReadAllText(filename);
        return Regex.IsMatch(content.Trim().Replace('_', '9') + "\n", @"^(?:\d \d \d\n){3}$");
    }
}
using System.Diagnostics;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename;
            if (UserInput.WantToSelect()) filename = UserInput.GetFilename();
            else
            {
                filename = "generated.txt";
                PuzzleGenerator.GenerateFile(filename);
            }

            State startState = StartStateFactory.GetStartState(filename);
            if (!SequenceAnalyzer.IsSolvable(startState.ToSequence()))
            {
                Console.WriteLine("This 8-puzzle is not solvable");
                Environment.Exit(1);
            }

            PathSearcher pathSearcher = new IDS();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            Node? goal = pathSearcher.Solve(startState);
            sw.Stop();
            Stack<State> route = pathSearcher.TraceRoute(goal);
            ResultOutput.PrintResult(route);
            Console.WriteLine("Search time: "+sw.ElapsedMilliseconds+" milliseconds");
        }
    }
}
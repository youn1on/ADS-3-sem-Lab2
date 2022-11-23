using System.ComponentModel.Design;
using System.Diagnostics;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename;
            if (UserInput.WantToSelectFile()) filename = UserInput.GetFilename();
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

            Console.WriteLine(startState);

            PathSearcher pathSearcher = UserInput.AStarSelected() ? new AStar() : new IDS();

            Measurement.Stopwatch.Restart();
            Node? goal = pathSearcher.Solve(startState);
            Measurement.Stopwatch.Stop();
            Stack<State> route = pathSearcher.TraceRoute(goal);
            ResultOutput.PrintResult(route);
            ResultOutput.PrintStatistics(pathSearcher);
            Console.ReadKey();
        }
    }
}
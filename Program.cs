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

            
            Measurement.Stopwatch.Restart();
            Node? goal = pathSearcher.Solve(startState);
            Measurement.Stopwatch.Stop();
            Stack<State> route = pathSearcher.TraceRoute(goal);
            ResultOutput.PrintResult(route);
            Console.WriteLine("Search time: "+ Measurement.Stopwatch.ElapsedMilliseconds+" milliseconds");
            Console.WriteLine("Iterations: " + Measurement.Iterations);
            Console.WriteLine("Dead ends: " + Measurement.DeadEnds);
            Console.WriteLine("Amount of states: " + Measurement.AmountOfStates);
            Console.WriteLine("Amount of states in memory: " + Measurement.AmountOfStatesInMemory);
            
        }
    }
}
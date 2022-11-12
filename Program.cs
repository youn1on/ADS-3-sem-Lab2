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

            Node? goal = AStar.Solve(startState);
            Stack<State> route = AStar.TraceRoute(goal);
            ResultOutput.PrintResult(route);
        }
    }
}
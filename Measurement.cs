using System.Diagnostics;

namespace Lab2;

public static class Measurement
{
    public static int Iterations = 0;
    public static int DeadEnds = 0;
    public static int AmountOfStates = 0;
    public static int AmountOfStatesInMemory = 0;
    public static Stopwatch Stopwatch = new Stopwatch();

    private static int MemoryLimit = 1073741824;
    private static int TimeLimit = 1_800_000;

    public static bool TimeAndMemoryConstraintIsViolated() => Stopwatch.ElapsedMilliseconds > TimeLimit || GC.GetTotalMemory(false) > MemoryLimit;
}
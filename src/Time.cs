using System.Diagnostics;

namespace Base.Engine;

public static class Time
{
    private static readonly Stopwatch stopwatch;
    private static double delta;

    public static double Delta
    {
        get
        {
            return delta;
        }

        set
        {
            delta = value;
        }
    }

    public const double Second = 1000000000;

    static Time()
    {
        stopwatch = Stopwatch.StartNew();
    }

    public static double GetTime()
    {
        return stopwatch.Elapsed.TotalNanoseconds;
    }
}
using System.Collections.Concurrent;

namespace MemLeakEvents.StaticAllocation;

public class StringAllocation
{
    private static ConcurrentBag<string> _staticStrings = new();
    public string Run()
    {
        var bigString = new string('x', 20 * 1024);
        _staticStrings.Add(bigString);
        return bigString;
    }
}
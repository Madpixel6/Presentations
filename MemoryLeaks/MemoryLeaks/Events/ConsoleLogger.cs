using System;

namespace MemLeakEvents.Events
{
    internal static class ConsoleLogger
    {
        public static bool IsEnabled { get; set; }

        public static void WriteLine(string message)
        {
            if(IsEnabled)
            {
                Console.WriteLine(message);
            }
        }
    }
}

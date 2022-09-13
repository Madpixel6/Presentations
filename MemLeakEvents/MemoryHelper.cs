using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using MemLeakEvents.Dto;

namespace MemLeakEvents;

public static class MemoryHelper
{
    public static PerformanceSummary GetClrMemoryInfo()
    {
        var currentProc = Process.GetCurrentProcess();
        var bytesInUse = currentProc.PrivateMemorySize64;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            var ctr1 = new PerformanceCounter("Process", "Private Bytes", currentProc.ProcessName);
            var ctr2 = new PerformanceCounter(".NET CLR Memory", "# Gen 0 Collections", currentProc.ProcessName);
            var ctr3 = new PerformanceCounter(".NET CLR Memory", "# Gen 1 Collections", currentProc.ProcessName);
            var ctr4 = new PerformanceCounter(".NET CLR Memory", "# Gen 2 Collections", currentProc.ProcessName);
            var ctr5 = new PerformanceCounter(".NET CLR Memory", "Gen 0 heap size", currentProc.ProcessName);

            return new PerformanceSummary
            {
                BytesInUse = bytesInUse,
                PrivateBytes = ctr1.NextValue(),
                Gen0Collections = ctr2.NextValue(),
                Gen1Collections = ctr3.NextValue(),
                Gen2Collections = ctr4.NextValue(),
                Gen0HeapSize = ctr5.NextValue()
            };
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return new PerformanceSummary();
        }
        return new PerformanceSummary();
    }
}
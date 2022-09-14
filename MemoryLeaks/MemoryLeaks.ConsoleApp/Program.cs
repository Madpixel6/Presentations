using MemLeakEvents;

Console.WriteLine("Press any key to run...");
Console.ReadKey();

Console.WriteLine("String allocation scenario");
const int stringsToAllocate = 1000; // ~20MB
for (int i = 0; i < stringsToAllocate; i++)
{
    MemLeaks.RunStringAllocation();
}
Console.WriteLine("Finished");
Console.ReadLine();

Console.WriteLine("Never terminating thread scenario");
MemLeaks.RunNeverTerminatingThread();
Console.WriteLine("Finished");
Console.ReadLine();

Console.WriteLine("Xml without a cache scenario");
MemLeaks.RunXmlMemoryLeak();
Console.WriteLine("Finished");
Console.ReadLine();

Console.WriteLine("Xml with a cache scenario");
MemLeaks.RunXmlCached();
Console.WriteLine("Finished");
Console.ReadLine();


// Console.WriteLine("Events scenario");
// MemLeaks.RunEventsMemoryLeak();
// Console.WriteLine("Finished");
// Console.ReadLine();

Console.ReadKey();
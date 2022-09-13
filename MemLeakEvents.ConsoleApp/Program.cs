using MemLeakEvents;

Console.WriteLine("Press any key to run...");
Console.ReadKey();

Console.WriteLine("String allocation scenario");
MemLeaks.RunStringAllocation();
MemoryInformationHelper.GetClrMemoryInfo();

Console.WriteLine("Never terminating thread scenario");
MemLeaks.RunNeverTerminatingThread();
MemoryInformationHelper.GetClrMemoryInfo();

Console.WriteLine("Events scenario");
MemLeaks.RunEventsMemoryLeak();
MemoryInformationHelper.GetClrMemoryInfo();

Console.WriteLine("Xml without a cache scenario");
MemLeaks.RunXmlMemoryLeak();
MemoryInformationHelper.GetClrMemoryInfo();

Console.WriteLine("Xml with a cache scenario");
MemLeaks.RunXmlCached();
MemoryInformationHelper.GetClrMemoryInfo();

Console.ReadKey();
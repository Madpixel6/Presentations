using System;
using MemLeakEvents.Events;
using MemLeakEvents.LiveStack;
using MemLeakEvents.StaticAllocation;
using MemLeakEvents.Xml;

namespace MemLeakEvents
{
    public static class MemLeaks
    {

        public static string RunStringAllocation()
        {
            var staticAllocation = new StringAllocation();
            var result = staticAllocation.Run();

            return result;
        }
        public static void RunXmlMemoryLeak()
        {
            var xmlLeak = new XmlLeak();
            xmlLeak.Run();
        }

        public static void RunXmlCached()
        {
            var xmlCached = new XmlWithCache();
            xmlCached.Run();
        }

        public static void RunNeverTerminatingThread()
        {
            for (var i = 0; i < 10; i++)
            {
                var notificationPusher = new TicksCounter();
                notificationPusher.GetTicks();
            }
            //GC.Collect();
            //GC.WaitForPendingFinalizers();
        }

        public static void RunEventsMemoryLeak()
        {
            var eventsLeak = new EventsLeak();
            eventsLeak.Run();
        }
    }
}
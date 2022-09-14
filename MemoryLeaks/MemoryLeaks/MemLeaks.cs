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

        /// <summary>
        /// Runs 10 threads with Timer that will never terminate
        /// </summary>
        public static void RunNeverTerminatingThread()
        {
            for (var i = 0; i < 10; i++)
            {
                var notificationPusher = new TicksCounter();
                notificationPusher.GetTicks();
            }
        }

        public static void RunEventsMemoryLeak(bool isUnsubscribing = false)
        {
            var eventsLeak = new EventsLeak();
            eventsLeak.Run(isUnsubscribing);
        }
    }
}
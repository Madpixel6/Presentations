using System;

namespace MemLeakEvents.Events
{
    public class EventsLeak
    {
        public void Run(bool isUnsubscribing = false)
        {
            const int numberOfSubscribers = 50;

            var publisher = new EventPublisher();

            for (var i = 0; i < numberOfSubscribers; i++)
            {
                var subscriber = new EventSubscriber(publisher, i);
                subscriber.Subscribe();

                publisher.PublishEvents();

                if (isUnsubscribing)
                {
                    subscriber.Unsubscribe();
                }

                subscriber = null;
            }

            // DEMO: Force GC to collect unused memory
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
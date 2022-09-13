using System;
using System.Collections.Generic;

namespace MemLeakEvents.Events
{
    internal class EventSubscriber
    {
        private readonly int _id;
        private readonly ICollection<Guid> _collectedGuids;
        private readonly EventPublisher _eventPublisher;

        public EventSubscriber(EventPublisher eventPublisher, int id)
        {
            _collectedGuids = new List<Guid>();
            _id = id;
            _eventPublisher = eventPublisher;
        }

        public void Subscribe()
        {
            _eventPublisher.SomeEvent += OnSomeEvent;
        }

        private void OnSomeEvent(object sender, Guid guid)
        {
            _collectedGuids.Add(guid);

            ConsoleLogger.WriteLine($"{nameof(EventSubscriber)} {_id}: OnSomeEvent received {{{guid}}}");
        }

        public void Unsubscribe()
        {
            _eventPublisher.SomeEvent -= OnSomeEvent;
        }
    }
}
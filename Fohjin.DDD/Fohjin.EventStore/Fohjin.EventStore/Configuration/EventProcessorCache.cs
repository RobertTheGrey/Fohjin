using System;
using System.Collections.Generic;

namespace Fohjin.EventStore.Configuration
{
    public class EventProcessorCache
    {
        private readonly Dictionary<Type, IEnumerable<EventProcessor>> _cache;

        public EventProcessorCache()
        {
            _cache = new Dictionary<Type, IEnumerable<EventProcessor>>();
        }

        public bool TryGetEventProcessorsFor(Type domainEventType, out IEnumerable<EventProcessor> eventProcessors)
        {
            return _cache.TryGetValue(domainEventType, out eventProcessors);
        }

        public void RegisterEvent(Type domainEventType)
        {
            if (_cache.ContainsKey(domainEventType))
                return;

            _cache.Add(domainEventType, new List<EventProcessor>());
        }

        public void RegisterEventProcessors(Type domainEventType, IEnumerable<EventProcessor> eventProcessors)
        {
            _cache.Add(domainEventType, eventProcessors);
        }
    }
}
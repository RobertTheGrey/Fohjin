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
<<<<<<< HEAD
=======
        }

        public void RegisterEvent(Type domainEventType)
        {
            if (_cache.ContainsKey(domainEventType))
                return;

            _cache.Add(domainEventType, new List<EventProcessor>());
>>>>>>> Refactoring to the PreProcessor now it takes events instead of entities. So now there is no need to discover events anymore (at least not from the entities) bringing the required methods back to one.
        }

        public void RegisterEventProcessors(Type domainEventType, IEnumerable<EventProcessor> eventProcessors)
        {
<<<<<<< HEAD
            if (_cache.ContainsKey(domainEventType))
                return;

=======
>>>>>>> Refactoring to the PreProcessor now it takes events instead of entities. So now there is no need to discover events anymore (at least not from the entities) bringing the required methods back to one.
            _cache.Add(domainEventType, eventProcessors);
        }
    }
}
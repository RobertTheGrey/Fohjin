using System;
using System.Collections.Generic;
using Fohjin.EventStore.Reflection;

namespace Fohjin.EventStore.Configuration
{
    public class PreProcessor
    {
        private readonly EventProcessorCache _eventProcessorCache;
        private readonly EventAccessor _eventAccessor;
        private readonly List<Type> _registeredEventTypes;

        public PreProcessor(EventProcessorCache eventProcessorCache, EventAccessor eventAccessor)
        {
            _eventProcessorCache = eventProcessorCache;
            _eventAccessor = eventAccessor;
            _registeredEventTypes = new List<Type>();
        }

        public void RegisterForPreProcessing<TEvent>()
        {
            RegisterForPreProcessing(typeof(TEvent));
        }

        public void RegisterForPreProcessing(Type eventType)
        {
            _registeredEventTypes.Add(eventType);
        }

        public void Process()
        {
            _registeredEventTypes.ForEach(ProcessEvent);
        }

        private void ProcessEvent(Type eventType)
        {
<<<<<<< HEAD
            _eventProcessorCache.RegisterEventProcessors(eventType, _eventAccessor.BuildEventProcessors(eventType));
=======
            var eventProcessors = _eventAccessor.BuildEventProcessors(eventType);
            _eventProcessorCache.RegisterEventProcessors(eventType, eventProcessors);
>>>>>>> Refactoring to the PreProcessor now it takes events instead of entities. So now there is no need to discover events anymore (at least not from the entities) bringing the required methods back to one.
        }
    }
}
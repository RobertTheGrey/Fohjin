﻿using System;
using System.Linq;
using System.Collections.Generic;
using Castle.Core.Interceptor;
using Fohjin.EventStore.Configuration;

namespace Fohjin.EventStore.Infrastructure
{
    public interface IEventProvider
    {
        Guid Id { get; }
        int Version { get; }
        IEnumerable<IDomainEvent> GetChanges();

        void Clear();
        void LoadFromHistory(IEnumerable<IDomainEvent> domainEvents);
        void UpdateVersion(int version);
    }

    public class EventProvider : IEventProvider, IInterceptor
    {
        private readonly Type _hostType;
        private readonly EventProcessorCache _eventProcessorCache;
        private readonly List<IDomainEvent> _appliedEvents;
        private readonly Dictionary<string, object> _internalState;

        public Guid Id { get; protected set; }
        public int Version { get; protected set; }
        public int EventVersion { get; protected set; }

        public EventProvider(Type hostType, EventProcessorCache eventProcessorCache)
        {
            _hostType = hostType;
            _eventProcessorCache = eventProcessorCache;
            EventVersion = 0;
            _appliedEvents = new List<IDomainEvent>();
            _internalState = new Dictionary<string, object>();
        }

        IEnumerable<IDomainEvent> IEventProvider.GetChanges()
        {
            return _appliedEvents;
        }

        void IEventProvider.Clear()
        {
            _appliedEvents.Clear();
        }

        void IEventProvider.LoadFromHistory(IEnumerable<IDomainEvent> domainEvents)
        {
            if (domainEvents.Count() == 0)
                return;

            domainEvents
                .ToList()
                .ForEach(domainEvent => apply(domainEvent.GetType(), domainEvent));

            Version = domainEvents.Last().EventVersion;
            EventVersion = Version;
        }

        void IEventProvider.UpdateVersion(int version)
        {
            Version = version;
        }

        void IInterceptor.Intercept(IInvocation invocation)
        {
            Intercept(invocation);
        }

        private void Intercept(IInvocation invocation)
        {
            if (IsApplyMethod(invocation))
            {
                InterceptApplyMethod(invocation);
                return;
            }
            if (IsInternalStateProperty(invocation))
            {
                InterceptInternalStateProperty(invocation);
                return;
            }
            invocation.Proceed();
        }

        private static bool IsApplyMethod(IInvocation invocation)
        {
            return invocation.Method.Name == "Apply";
        }

        private void InterceptApplyMethod(IInvocation invocation)
        {
            var domainEvent = (IDomainEvent)invocation.Arguments.First();

            domainEvent.AggregateId = Id;
            domainEvent.EventVersion = ++EventVersion;
            apply(domainEvent.GetType(), domainEvent);
            _appliedEvents.Add(domainEvent);
        }

        private bool IsInternalStateProperty(IInvocation invocation)
        {
            return
                invocation.Method.DeclaringType == _hostType &&
                invocation.Method.Name.StartsWith("get_") &&
                _internalState.ContainsKey(invocation.Method.Name.Substring(4));
        }

        private void InterceptInternalStateProperty(IInvocation invocation)
        {
            invocation.ReturnValue = _internalState[invocation.Method.Name.Substring(4)];
        }

        private void apply(Type eventType, IDomainEvent domainEvent)
        {
            IEnumerable<EventProcessor> eventProcessors; 
            if (!_eventProcessorCache.TryGetEventProcessorsFor(eventType, out eventProcessors))
                throw new UnregisteredDomainEventException(string.Format("The requested class '{0}' is not registered as a domain event", eventType.FullName));

            eventProcessors
                .ToList()
                .ForEach(eventProcessor => eventProcessor.EventPropertyProcessor(domainEvent, _internalState));
        }
    }
}
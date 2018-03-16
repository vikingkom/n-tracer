using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using NTracer.Communication;

namespace NTracer.Client
{
    public class Processor : ILocalConnection
    {
        private readonly BlockingCollection<ScopeEvent> _events = new BlockingCollection<ScopeEvent>(MaxEventsCount);
        private const int MaxEventsCount = 1000;

        public Processor(IHandler[] handlers)
        {
            Task.Factory.StartNew(() =>
            {
                foreach (var @event in _events.GetConsumingEnumerable())
                {
                    foreach (var handler in handlers)
                    {
                        handler.Handle(new []{@event});
                    }
                }
            });
        }

        public void OpenScope(string parentScopeId, string newScopeId, bool isParallel)
        {
            var message = new OpenScopeEvent(parentScopeId,newScopeId, isParallel, DateTimeOffset.Now);
            _events.Add(message);
        }

        public void CloseScope(string scopeId)
        {
            var message = new CloseScopeEvent(scopeId, DateTimeOffset.Now);
            _events.Add(message);
        }

        public void SetProperty(string scopeId, string propertyName, TracerValue value)
        {
            var message = new SetPropertyEvent(scopeId, propertyName, value);
            _events.Add(message);
        }

        public void Write(string scopeId, string eventName, TracerValue content)
        {
            var message = new WriteEvent(scopeId, eventName, content, DateTimeOffset.Now);
            _events.Add(message);
        }
    }
}
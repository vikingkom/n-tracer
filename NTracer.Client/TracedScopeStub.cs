using System.Collections.Generic;
using System.Collections.ObjectModel;
using NTracer.Client.Core;
using NTracer.Communication;

namespace NTracer.Client
{
    class TracedScopeStub : ITracedScope
    {
        public TracedScopeStub()
        {
            Id = "stub";
            RootId = null;
        }

        public string Id { get; }
        public string RootId { get; }

        public ITracedScope SetParallelChildrenMode()
        {
            return this;
        }

        public ITracedScope SetSequentialChildrenMode()
        {
            return this;
        }

        public ITracedScope SetProperty(string propertyName, TracerValue value)
        {
            return this;
        }

        public void RegisterAndPopulateEvent(LogEventInfo logEventInfo)
        {
        }

        public void Dispose()
        {
            
        }
    }

    public class LogEventInfo
    {

    }
}
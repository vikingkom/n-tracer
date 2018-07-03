using System;
using NTracer.Server.Core.Sink.Configuration;

namespace NTracer.Server.Core.Sink.Run
{
    public class SinkRunner : IDisposable
    {
        public event Action<ScopeItem> ScopeItemAdded;
        public SinkRunner(ISinkSource sinkSource, SinkScopeConfiguration sinkScopeConfiguration)
        {
        }

        public void Dispose()
        {
        }

        protected virtual void OnScopeItemAdded(ScopeItem obj)
        {
            ScopeItemAdded?.Invoke(obj);
        }
    }
}
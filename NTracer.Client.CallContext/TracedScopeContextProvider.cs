using System;
using NTracer.Client.Core;
using NTracer.Communication;

namespace NTracer.Client.CallContext
{
    public class TracedScopeContextProvider : IContextProvider
    {
        private readonly ILocalConnection _localConnection;
        private const string CurrentTraceLayerContextKeyName = "CurrentTraceLayerContextKey";

        public TracedScopeContextProvider(ILocalConnection localConnection)
        {
            _localConnection = localConnection;
        }

        private IScopeContext GetCurrentLayerContext()
        {
            var contextWrapper = (ScopeContextWrapper)System.Runtime.Remoting.Messaging.CallContext.LogicalGetData(CurrentTraceLayerContextKeyName);
            return contextWrapper?.ScopeContext;
        }

        public ITracedScope CreateScope(bool isParallel=false)
        {
            var currentLayerContext = GetCurrentLayerContext();
            TracedScope newTracedLayer = new TracedScope(currentLayerContext, this, _localConnection, isParallel);
            currentLayerContext?.NotifyLayerCreated(newTracedLayer);
            SetScopeContextAsCurrent(newTracedLayer.CurrentContext);
            return newTracedLayer;
        }

        public void SetScopeContextAsCurrent(IScopeContext layerContext)
        {
            if (layerContext == null)
                System.Runtime.Remoting.Messaging.CallContext.FreeNamedDataSlot(CurrentTraceLayerContextKeyName);
            else
            {
                var wrapper = new ScopeContextWrapper(layerContext);
                System.Runtime.Remoting.Messaging.CallContext.LogicalSetData(CurrentTraceLayerContextKeyName, wrapper);
            }
        }
    }
}
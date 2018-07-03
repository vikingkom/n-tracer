using NTracer.Client.Core;

namespace NTracer.Client
{
    public class StubTracedScopeContextProvider : IContextProvider
    {
        private readonly TracedScopeStub _scopeStub = new TracedScopeStub();

        public ITracedScope CreateScope(bool isParallel = false)
        {
            return _scopeStub;
        }

        public void SetScopeContextAsCurrent(IScopeContext layerContext)
        {
        }
    }
}
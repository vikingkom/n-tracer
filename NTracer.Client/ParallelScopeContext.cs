using NTracer.Client.Core;

namespace NTracer.Client
{
    public class ParallelScopeContext : IScopeContext
    {
        public ITracedScope Scope { get; }
        public bool HasChildren { get; set; }

        public ParallelScopeContext(ITracedScope scope)
        {
            Scope = scope;
        }

        public void NotifyLayerCreated(ITracedScope tracedScope)
        {
            HasChildren = true;
        }

        public void NotifyLayerDisposed(ITracedScope tracedScope)
        {

        }

    }
}
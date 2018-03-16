namespace NTracer.Client.Core
{
    public interface IScopeContext
    {
        void NotifyLayerCreated(ITracedScope tracedScope);
        void NotifyLayerDisposed(ITracedScope tracedScope);
        ITracedScope Scope { get; }
    }
}
namespace NTracer.Client.Core
{
    public interface IContextProvider
    {
        ITracedScope CreateScope(bool isParallel = false);
        void SetScopeContextAsCurrent(IScopeContext layerContext);
    }
}
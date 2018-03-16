namespace NTracer.Client.Core
{
    public class ScopeContextWrapper
    {
        public IScopeContext ScopeContext { get; set; }

        public ScopeContextWrapper()
        {
        }

        public ScopeContextWrapper(IScopeContext scopeContext)
        {
            ScopeContext = scopeContext;
        }
    }
}
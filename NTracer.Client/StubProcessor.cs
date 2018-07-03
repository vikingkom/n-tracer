using NTracer.Communication;

namespace NTracer.Client
{
    public class StubProcessor : ILocalConnection
    {
        public void OpenScope(string parentScopeId, string newScopeId, bool isParallel)
        {
        }

        public void CloseScope(string scopeId)
        {
        }

        public void SetProperty(string scopeId, string propertyName, TracerValue tracerValue)
        {
        }

        public void Write(string scopeId, string eventName, TracerValue content)
        {
        }
    }
}
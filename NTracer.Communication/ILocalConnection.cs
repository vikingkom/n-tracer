namespace NTracer.Communication
{
    public interface ILocalConnection
    {
        void OpenScope(string parentScopeId, string newScopeId, bool isParallel);
        void CloseScope(string scopeId);
        void SetProperty(string scopeId, string propertyName, TracerValue tracerValue);
        void Write(string scopeId, string eventName, TracerValue content);
    }
}
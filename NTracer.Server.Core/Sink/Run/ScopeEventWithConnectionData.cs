using NTracer.Communication;

namespace NTracer.Server.Core.Sink.Run
{
    public class ScopeEventWithConnectionData<T> where T:ScopeEvent
    {
        public ScopeEventWithConnectionData(T scopeEvent, ConnectionData connectionData)
        {
            ScopeEvent = scopeEvent;
            ConnectionData = connectionData;
        }

        public T ScopeEvent { get; set; }
        public ConnectionData ConnectionData { get; set; }
    }
}
using System.Collections.Generic;

namespace NTracer.Communication
{
    public class ScopeEventsFromConnection
    {
        public string ConnectionId { get; set; }
        public ICollection<OpenScopeEvent> OpenScopeEvents { get; set; }
        public ICollection<CloseScopeEvent> CloseScopeEvents { get; set; }
        public ICollection<SetPropertyEvent> SetPropertyScopeEvents { get; set; }
        public ICollection<WriteEvent> WriteScopeEvents { get; set; }
    }

    public class ConnectionData
    {
        public string InstanceName { get; set; }
        public TracerValue Value { get; set; }
    }
}
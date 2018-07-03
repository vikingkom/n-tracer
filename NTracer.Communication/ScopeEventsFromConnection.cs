using System.Collections.Generic;

namespace NTracer.Communication
{
    public class ScopeEventsFromConnection
    {
        public string ConnectionId { get; set; }
        public ICollection<OpenScopeEvent> OpenScopeEvents { get; set; }
        public ICollection<CloseScopeEvent> CloseScopeEvents { get; set; }
        public ICollection<SetPropertyEvent> SetPropertyScopeEvents { get; set; }
        public ICollection<LogEvent> LogScopeEvents { get; set; }
    }
}
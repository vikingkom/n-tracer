using System;

namespace NTracer.Communication
{
    public class CloseScopeEvent : ScopeEvent
    {
        public CloseScopeEvent()
        {
        }

        public CloseScopeEvent(string scopeId, DateTimeOffset time)
        {
            ScopeId = scopeId;
            Time = time;
        }

        public DateTimeOffset Time { get; set; }

        public override string ToString()
        {
            return $"{nameof(Time)}: {Time}, {nameof(ScopeId)}: {ScopeId}";
        }
    }
}
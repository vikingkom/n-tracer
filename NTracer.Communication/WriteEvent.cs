using System;

namespace NTracer.Communication
{
    public class WriteEvent : ScopeEvent
    {
        public WriteEvent()
        {
        }

        public WriteEvent(string scopeId, string eventName, TracerValue value, DateTimeOffset time)
        {
            ScopeId = scopeId;
            Time = time;
            EventName = eventName;
            Value = value;
        }

        public DateTimeOffset Time { get; set; }
        public string EventName { get; set; }
        public TracerValue Value { get; set; }

        public override string ToString()
        {
            return $"{nameof(Time)}: {Time}, {nameof(ScopeId)}: {ScopeId}, {nameof(EventName)}: {EventName}, {nameof(Value)}: {Value}";
        }
    }
}
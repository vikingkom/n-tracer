using System;

namespace NTracer.Communication
{
    public class LogEvent : ScopeEvent
    {
        public LogEvent()
        {
        }

        public LogEvent(string scopeId, string eventName, TracerValue value, DateTimeOffset time)
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
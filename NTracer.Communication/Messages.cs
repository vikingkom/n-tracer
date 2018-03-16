using System;
using System.Runtime.Serialization;

namespace NTracer.Communication
{
    public abstract class ScopeEvent
    {
        public string ScopeId { get; set; }
    }

    public class OpenScopeEvent : ScopeEvent
    {
        public OpenScopeEvent()
        {
        }

        public OpenScopeEvent(string parentId, string scopeId, bool isParallel, DateTimeOffset time)
        {
            ParentId = parentId;
            ScopeId = scopeId;
            IsParallel = isParallel;
            Time = time;
        }

        public string ParentId { get; set; }
        public bool IsParallel { get; set; }
        public DateTimeOffset Time { get; set; }

        public override string ToString()
        {
            return $"{nameof(Time)}: {Time}, {nameof(ScopeId)}: {ScopeId}, {nameof(ParentId)}: {ParentId}, {nameof(IsParallel)}: {IsParallel}";
        }
    }

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

    public class SetPropertyEvent : ScopeEvent
    {
        public SetPropertyEvent()
        {
        }

        public SetPropertyEvent(string scopeId, string propertyName, TracerValue value)
        {
            ScopeId = scopeId;
            PropertyName = propertyName;
            Value = value;
        }

        public string PropertyName { get; set; }
        public TracerValue Value { get; set; }

        public override string ToString()
        {
            return $"{nameof(ScopeId)}: {ScopeId}, {nameof(PropertyName)}: {PropertyName}, {nameof(Value)}: {Value}";
        }
    }

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
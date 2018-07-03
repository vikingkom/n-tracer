using System;

namespace NTracer.Communication
{
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
}
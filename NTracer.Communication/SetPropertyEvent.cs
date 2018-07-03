namespace NTracer.Communication
{
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
}
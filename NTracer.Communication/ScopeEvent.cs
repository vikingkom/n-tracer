using System.Runtime.Serialization;

namespace NTracer.Communication
{
    public abstract class ScopeEvent
    {
        public string ScopeId { get; set; }
    }
}
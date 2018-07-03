using NTracer.Communication;

namespace NTracer.Server.Core.Sink.Configuration
{
    public class TagFilter 
    {
        public string Tag { get; set; }
        public TracerValue Value { get; set; }
        public MatchOperation MatchOperation { get; set; }
    }
}
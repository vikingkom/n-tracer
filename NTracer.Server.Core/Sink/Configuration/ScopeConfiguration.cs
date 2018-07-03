namespace NTracer.Server.Core.Sink.Configuration
{
    public class ScopeConfiguration
    {
        public string NameFilter { get; set; }
        public TagFilter TagFilter { get; set; }
        public ScopePropertyConfiguration PropertyConfiguration { get; set; }
    }
}
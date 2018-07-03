namespace NTracer.Server.Core.Sink.Configuration
{
    public class SinkConfiguration
    {
        public ScopeConfiguration Configuration { get; set; }
        public SinkConfiguration(ScopeConfiguration sinkConfiguration)
        {
            Configuration = sinkConfiguration;
        }
    }
}
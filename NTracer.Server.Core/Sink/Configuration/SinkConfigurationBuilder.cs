using System;

namespace NTracer.Server.Core.Sink.Configuration
{
    public class SinkConfigurationBuilder
    {
        public SinkConfiguration Build(Func<SinkScopeConfiguration, ScopeConfiguration> configuration)
        {
            return new SinkConfiguration(configuration(new SinkScopeConfiguration()));
        }
    }
}
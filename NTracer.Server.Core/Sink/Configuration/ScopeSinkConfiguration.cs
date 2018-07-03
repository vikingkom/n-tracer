using System;
using NTracer.Communication;

namespace NTracer.Server.Core.Sink.Configuration
{
    public class SinkScopeConfiguration
    {
        public ScopeConfiguration ByName(string name, Action<ScopePropertyConfiguration> properties)
        {
            var propertyConfiguration = new ScopePropertyConfiguration();
            properties?.Invoke(propertyConfiguration);
            return new ScopeConfiguration() {NameFilter = name, PropertyConfiguration = propertyConfiguration };
        }

        public ScopeConfiguration ByTag(string tag, TracerValue value, Action<ScopePropertyConfiguration> properties)
        {
            var propertyConfiguration = new ScopePropertyConfiguration();
            properties?.Invoke(propertyConfiguration);
            return new ScopeConfiguration() { TagFilter = new TagFilter()
            {
                Tag = tag,
                Value = value,
                MatchOperation = MatchOperation.Equals
            },PropertyConfiguration = propertyConfiguration};
        }
    }
}
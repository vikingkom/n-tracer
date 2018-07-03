using System;

namespace NTracer.Server.Core.Sink.Configuration
{
    public class ScopePropertyConfiguration
    {
        private bool _withClosure;
        private bool _withLogs;
        private ScopePropertyConfiguration _parentScope;

        public ScopePropertyConfiguration WithClosure()
        {
            _withClosure = true;
            return this;
        }

        public ScopePropertyConfiguration WithParent(Action<ScopePropertyConfiguration> parentConfiguration = null)
        {
            var parentConfig = new ScopePropertyConfiguration();
            parentConfiguration?.Invoke(parentConfig);
            _parentScope = parentConfig;
            return this;
        }

        public ScopePropertyConfiguration WithLogs()
        {
            _withLogs = true;
            return this;
        }
    }
}
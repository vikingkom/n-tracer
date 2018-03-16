using System;
using NTracer.Client.Core;
using NTracer.Communication;

namespace NTracer.Client
{
    public class TracedScope : ITracedScope
    {
        private readonly IContextProvider _contextProvider;
        private readonly ILocalConnection _connection;
        private SequentialScopeContext _sequentialScopeContext;
        private ParallelScopeContext _parallelScopeContext;
        private IScopeContext _currentContext;

        public string Id { get; }
        public IScopeContext ParentContext { get; private set; }

        public TracedScope(IScopeContext parentContext, IContextProvider contextProvider, ILocalConnection connection, bool isParallel = true)
        {
            _contextProvider = contextProvider;
            _connection = connection;
            Id = Guid.NewGuid().ToString("N");
            
            ParentContext = parentContext;
            _connection.OpenScope(parentContext?.Scope.Id, Id, isParallel);
            if (isParallel)
                SetParallelChildrenMode();
            else
                SetSequentialChildrenMode();
        }
        
        public ITracedScope SetProperty(string propertyName, TracerValue value)
        {
            _connection.SetProperty(Id, propertyName, value);
            return this;
        }

        public ITracedScope SetParallelChildrenMode()
        {
            _currentContext = _parallelScopeContext?? (_parallelScopeContext = new ParallelScopeContext(this));
            _contextProvider.SetScopeContextAsCurrent(_currentContext);
            return this;
        }

        public ITracedScope SetSequentialChildrenMode()
        {
            _currentContext = _sequentialScopeContext?? (_sequentialScopeContext = new SequentialScopeContext(this));
            _contextProvider.SetScopeContextAsCurrent(_currentContext);
            return this;
        }

        public IScopeContext CurrentContext => _currentContext;
            
        

        //public void RegisterAndPopulateEvent(LogEventInfo logEventInfo)
        //{
        //    logEventInfo.Properties["scope(from start)"] = (int)DateTime.Now.Subtract(StartTime).TotalMilliseconds;
        //    logEventInfo.Properties[LayerIdKeyName] = Id;
        //    foreach (var property in GetProperties())
        //    {
        //        logEventInfo.Properties[property.Key] = property.Value;
        //    }
        //}

        public void Dispose()
        {
            Close();
        }

        //private IDictionary<object, object> GetLayerProperties()
        //{
        //    var endTime = DateTime.Now;
        //    var layerProperties = GetProperties();
        //    layerProperties[LayerIdKeyName] = Id;
        //    layerProperties[ParentLayerIdKeyName] = ParentContext?.Scope.Id;
        //    layerProperties[RootLayerIdKeyName] = RootId;
        //    layerProperties["scope(startTime)"] = StartTime;
        //    layerProperties["scope(endTime)"] = endTime;
        //    layerProperties["scope(raw duration)"] = (int) endTime.Subtract(StartTime).TotalMilliseconds;
        //    layerProperties["scope(has parallel child)"] = _parallelScopeContext.HasChildren;
        //    layerProperties["scope(pure duration)"] =
        //        (int) (endTime.Subtract(StartTime).Subtract(_sequentialScopeContext.Duration)).TotalMilliseconds;
        //    return layerProperties;
        //}

        private void Close()
        {
            _connection.CloseScope(Id);
            _contextProvider.SetScopeContextAsCurrent(ParentContext);
            ParentContext?.NotifyLayerDisposed(this);
            ParentContext = null;
            _parallelScopeContext = null;
            _parallelScopeContext = null;
            _currentContext = null;
        }
    }
}
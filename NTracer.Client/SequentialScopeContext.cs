using System;
using NTracer.Client.Core;

namespace NTracer.Client
{
    public class SequentialScopeContext : IScopeContext
    {
        public ITracedScope Scope { get; }

        private int _openedChildrenCount;
        private DateTime _windowStartTime;
        private TimeSpan _totalWindowSum = TimeSpan.Zero;

        public SequentialScopeContext(ITracedScope scope)
        {
            Scope = scope;
        }

        public void NotifyLayerCreated(ITracedScope tracedScope)
        {
            if (_openedChildrenCount == 0)
                _windowStartTime = DateTime.Now;
            
            _openedChildrenCount++;
        }

        public void NotifyLayerDisposed(ITracedScope tracedScope)
        {
            _openedChildrenCount--;
            if (_openedChildrenCount == 0)
                _totalWindowSum = _totalWindowSum.Add(DateTime.Now.Subtract(_windowStartTime));
        }

        public TimeSpan Duration => _totalWindowSum;
    }
}
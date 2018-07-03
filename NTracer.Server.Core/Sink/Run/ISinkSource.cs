using System;
using System.Collections.Generic;
using NTracer.Communication;

namespace NTracer.Server.Core.Sink.Run
{
    public interface ISinkSource
    {
        event Action<ScopeEventWithConnectionData<OpenScopeEvent>> OpenScopeEventAdded;
        event Action<ScopeEventWithConnectionData<CloseScopeEvent>> CloseScopeEventAdded;
        event Action<ScopeEventWithConnectionData<SetPropertyEvent>> SetPropertyScopeEventAdded;
        event Action<ScopeEventWithConnectionData<LogEvent>> LogScopeEventAdded;
    }
}
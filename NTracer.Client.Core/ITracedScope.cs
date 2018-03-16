using System;
using System.Collections.Generic;
using NTracer.Communication;

namespace NTracer.Client.Core
{
    public interface ITracedScope: IDisposable
    {
        string Id { get; }
        ITracedScope SetParallelChildrenMode();
        ITracedScope SetSequentialChildrenMode();
        ITracedScope SetProperty(string propertyName, TracerValue value);

    }
}
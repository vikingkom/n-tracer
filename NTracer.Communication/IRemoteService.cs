using System;
using System.Threading.Tasks;

namespace NTracer.Communication
{
    public interface IRemoteService
    {
        Task SendBatch(ScopeEventsFromConnection eventsFromConnection);
        Task<string> Connect(ConnectionData connection);
    }
}
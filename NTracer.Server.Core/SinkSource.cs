using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NTracer.Communication;
using NTracer.Server.Core.Repositories;
using NTracer.Server.Core.Sink.Run;

namespace NTracer.Server.Core
{
    public class SinkSource : IRemoteService, ISinkSource
    {
        public event Action<ScopeEventWithConnectionData<OpenScopeEvent>> OpenScopeEventAdded;
        public event Action<ScopeEventWithConnectionData<CloseScopeEvent>> CloseScopeEventAdded;
        public event Action<ScopeEventWithConnectionData<SetPropertyEvent>> SetPropertyScopeEventAdded;
        public event Action<ScopeEventWithConnectionData<LogEvent>> LogScopeEventAdded;
        private readonly IConnectionRepository _connectionRepository;

        public SinkSource(IConnectionRepository connectionRepository)
        {
            _connectionRepository = connectionRepository;
        }

        public async Task SendBatch(ScopeEventsFromConnection eventsFromConnection)
        {
            var connectionData = _connectionRepository.GetConnectionDataById(eventsFromConnection.ConnectionId);
            DoEventProcessing(OpenScopeEventAdded, eventsFromConnection.OpenScopeEvents, connectionData);
            DoEventProcessing(CloseScopeEventAdded, eventsFromConnection.CloseScopeEvents, connectionData);
            DoEventProcessing(SetPropertyScopeEventAdded, eventsFromConnection.SetPropertyScopeEvents, connectionData);
            DoEventProcessing(LogScopeEventAdded, eventsFromConnection.LogScopeEvents, connectionData);
        }

        public Task<string> Connect(ConnectionData connection)
        {
            var connectionId = _connectionRepository.AddConnection(connection);
            return Task.FromResult(connectionId);
        }

        private static void DoEventProcessing<T>(Action<ScopeEventWithConnectionData<T>> @event,
            IEnumerable<T> collection, ConnectionData connectionData) where T : ScopeEvent
        {
            if(@event != null)
                foreach (var item in collection)
                {
                    @event(new ScopeEventWithConnectionData<T>(item, connectionData));
                }
        }
    }
}

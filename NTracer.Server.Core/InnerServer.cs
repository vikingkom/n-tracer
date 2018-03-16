using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NTracer.Communication;

namespace NTracer.Server.Core
{
    public class InnerServer : IRemoteService
    {
        private readonly IConnectionRepository _connectionRepository;
        private readonly ITracedScopeRepository _tracedScopeRepository;

        public InnerServer(IConnectionRepository connectionRepository, ITracedScopeRepository tracedScopeRepository)
        {
            _connectionRepository = connectionRepository;
            _tracedScopeRepository = tracedScopeRepository;
        }

        public async Task SendBatch(ScopeEventsFromConnection eventsFromConnection)
        {
            return;
        }

        public Task<string> Connect(ConnectionData connection)
        {
            return Task.FromResult("connectionId");
            var connectionId = _connectionRepository.AddConnection(connection.InstanceName, connection.Value);
            return Task.FromResult(connectionId);
        }
    }

    public class ConnectionSession
    {
        public string ConnectionId { get; set; }
        public string InstanceName { get; set; }
        public TracerValue Tags { get; set; }
    }
}

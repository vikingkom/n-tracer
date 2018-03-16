using System;
using System.Net;
using System.Threading.Tasks;
using NTracer.Communication;

namespace NTracer.Client
{
    public class RemoteSenderHandler : IHandler
    {
        private string _connectionId;
        private readonly RemoteServiceClient _remoteServiceClient;

        public RemoteSenderHandler(RemoteServiceClient remoteServiceClient)
        {
            _remoteServiceClient = remoteServiceClient;
        }

        public async Task Connect(string instanceName, TracerValue tags)
        {
            if(_connectionId == null)
                _connectionId  = await _remoteServiceClient.Connect(instanceName, tags);
        }

        public async Task Handle(ScopeEvent[] @events)
        {
            try
            {
                await _remoteServiceClient.SendBatch(_connectionId, @events);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
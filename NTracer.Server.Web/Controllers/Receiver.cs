using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NTracer.Communication;
using NTracer.Server.Core;

namespace NTracer.Server.Web.Controllers
{
    public class Receiver : ControllerBase, IRemoteService
    {
        private readonly InnerServer _innerServer;

        public Receiver(InnerServer innerServer)
        {
            _innerServer = innerServer;
        }

        [HttpPost]
        public Task SendBatch([FromBody]ScopeEventsFromConnection eventsFromConnection)
        {
            return _innerServer.SendBatch(eventsFromConnection);
        }

        [HttpPost]
        public Task<string> Connect([FromBody]ConnectionData connection)
        {
            return _innerServer.Connect(connection);
        }
    }
}
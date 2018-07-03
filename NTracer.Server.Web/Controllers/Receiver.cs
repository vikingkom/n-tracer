using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NTracer.Communication;
using NTracer.Server.Core;

namespace NTracer.Server.Web.Controllers
{
    public class Receiver : ControllerBase, IRemoteService
    {
        private readonly SinkSource _sinkSource;

        public Receiver(SinkSource sinkSource)
        {
            _sinkSource = sinkSource;
        }

        [HttpPost]
        public Task SendBatch([FromBody]ScopeEventsFromConnection eventsFromConnection)
        {
            return _sinkSource.SendBatch(eventsFromConnection);
        }

        [HttpPost]
        public Task<string> Connect([FromBody]ConnectionData connection)
        {
            return _sinkSource.Connect(connection);
        }
    }
}
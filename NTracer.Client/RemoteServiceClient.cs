using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NTracer.Communication;

namespace NTracer.Client
{
    public class RemoteServiceClient
    {
        private readonly HttpClient _client;
        public RemoteServiceClient(Uri endpoint)
        {
            _client = new HttpClient {BaseAddress = endpoint};
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task SendBatch(string connectionId, ScopeEvent[] scopeEvents)
        {
            try
            {
                var data = new ScopeEventsFromConnection
                {
                    ConnectionId = connectionId,
                    OpenScopeEvents = scopeEvents.OfType<OpenScopeEvent>().ToList(),
                    CloseScopeEvents = scopeEvents.OfType<CloseScopeEvent>().ToList(),
                    WriteScopeEvents = scopeEvents.OfType<WriteEvent>().ToList(),
                    SetPropertyScopeEvents = scopeEvents.OfType<SetPropertyEvent>().ToList()
                };
                var content = AsJson(data);
                var response = await _client.PostAsync("Receiver/SendBatch", content);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }

        public async Task<string> Connect(string instanceName, TracerValue value)
        {
            try
            {
                var data = new ConnectionData {InstanceName = instanceName, Value = value};
                var content = AsJson(data);
                var result = await _client.PostAsync("Receiver/Connect", content);
                result.EnsureSuccessStatusCode();
                return await result.Content.ReadAsAsync<string>();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                throw ex;
            }
        }

        public static StringContent AsJson(object o)
            => new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json");

    }
}
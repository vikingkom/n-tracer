using System;
using System.Collections.Generic;
using System.Linq;
using NTracer.Communication;

namespace NTracer.Server.Core.Repositories
{
    public class InMemoryConnectionRepository : IConnectionRepository
    {
        private readonly Dictionary<string, ConnectionData> _connectionDatas = new Dictionary<string, ConnectionData>();
        public string AddConnection(ConnectionData connectionData)
        {
            var sameConnection = _connectionDatas.Where(w =>
                w.Value.InstanceName == connectionData.InstanceName && w.Value.Value == connectionData.Value).Select(s=>s.Key).FirstOrDefault();
            if (sameConnection != null)
                return sameConnection;
            var guid = Guid.NewGuid().ToString("N");
            _connectionDatas.Add(guid, connectionData);
            return guid;
        }

        public ConnectionData GetConnectionDataById(string connectionId)
        {
            return _connectionDatas.TryGetValue(connectionId, out var result) ? result : null;
        }
    }
}
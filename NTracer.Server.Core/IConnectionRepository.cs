using NTracer.Communication;

namespace NTracer.Server.Core
{
    public interface IConnectionRepository
    {
        string AddConnection(string instanceName, TracerValue tags);
        string GetConnectionIdBySessionId(string sessionId);
        string GetConnectionIdByAppAndInstanceNames(string appName, string instanceName);
        string GetApplicationStorageId(string connectionId);
    }

    public class ConnectionRepository : IConnectionRepository
    {
        public string AddConnection(string instanceName, TracerValue tags)
        {
            throw new System.NotImplementedException();
        }

        public string GetConnectionIdBySessionId(string sessionId)
        {
            throw new System.NotImplementedException();
        }

        public string GetConnectionIdByAppAndInstanceNames(string appName, string instanceName)
        {
            throw new System.NotImplementedException();
        }

        public string GetApplicationStorageId(string connectionId)
        {
            throw new System.NotImplementedException();
        }
    }
}
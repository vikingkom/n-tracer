using NTracer.Communication;

namespace NTracer.Server.Core.Repositories
{
    public interface IConnectionRepository
    {
        string AddConnection(ConnectionData connectionData);
        ConnectionData GetConnectionDataById(string connectionId);
    }
}
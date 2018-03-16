using System.Threading.Tasks;
using NTracer.Communication;

namespace NTracer.Client
{
    public interface IHandler
    {
        Task Handle(ScopeEvent[] @events);
    }
}